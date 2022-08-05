using Neo.SmartContract.Framework;
using System;
using System.ComponentModel;
using Neo;
using Neo.Cryptography.ECC;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Native;
using Neo.SmartContract.Framework.Services;

namespace CommitteeInfoContract
{
    [DisplayName("CommitteeInfoContract")]
    [ManifestExtra("Author", "NEO")]
    [ManifestExtra("Email", "developer@neo.org")]
    [ManifestExtra("Description", "This is a Neo3 Contract")]
    public partial class CommitteeInfoContract : SmartContract
    {

        private static byte[] _signHead = new byte[] { 0x0c, 0x21 };

        private static byte[] _signTail = new byte[] { 0x41, 0x56, 0xe7, 0xb3, 0x27 };


        private static readonly byte[] CommitteeKeyPrefix = new byte[] { 0x77 };
        private static byte[] GetCommitteeKey(UInt160 sender) => CommitteeKeyPrefix.Concat((byte[])sender);


        public static bool SetInfo(UInt160 sender, string name, string location, string website, string email, string github, string telegram, string twitter, string description, string logo)
        {
            Assert(Runtime.CheckWitness(sender), "Forbidden");

            var candidates = NEO.GetCandidates();
            bool isCandidate = false;
            foreach (var (c, v) in candidates)
            {
                var hash = ConvertToHash160(c);
                if (sender == hash)
                {
                    isCandidate = true;
                    break;
                }
            }
            Assert(isCandidate, "Sender is not Candidate");

            var entity = new CommitteeInfo()
            {
                Hash = sender,
                Name = name,
                Location = location,
                WebSite = website,
                Email = email,
                GitHub = github,
                Telegram = telegram,
                Twitter = twitter,
                Description = description,
                Logo = logo,
            };
            StoragePut(GetCommitteeKey(sender), StdLib.Serialize(entity));
            return true;
        }


        public static CommitteeInfo GetInfo(UInt160 candidate)
        {
            var value = StorageGet(GetCommitteeKey(candidate));
            if (value?.Length > 0)
            {
                return (CommitteeInfo)StdLib.Deserialize(value);
            }
            return null;
        }


        public static CommitteeInfo[] GetAllInfo()
        {
            var iterator = (Iterator<KeyValue>)StorageFind(CommitteeKeyPrefix);
            var result = new CommitteeInfo[0];
            while (iterator.Next())
            {
                var keyValue = iterator.Value;
                if (keyValue.Value != null)
                {
                    Append(result, keyValue.Value);
                }
            }
            return result;
        }


        public static bool DeleteInfo(UInt160 candidate)
        {
            Assert(Runtime.CheckWitness(candidate) || Verify(), "Forbidden");
            var key = GetCommitteeKey(candidate);
            var value = StorageGet(GetCommitteeKey(candidate));
            if (value?.Length > 0)
            {
                StorageDelete(key);
                return true;
            }
            return false;
        }



        private static UInt160 ConvertToHash160(ECPoint point)
        {
            var data = _signHead.Concat((byte[])point).Concat(_signTail);
            var hash = CryptoLib.Ripemd160(CryptoLib.Sha256((ByteString)data));
            return (UInt160)hash;
        }
    }
}
