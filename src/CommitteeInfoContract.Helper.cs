using System;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Services;

namespace CommitteeInfoContract
{
    partial class CommitteeInfoContract
    {
        /// <summary>
        /// 断言
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        private static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception(message);
            }
        }


        [OpCode(OpCode.APPEND)]
        private static extern void Append<T>(T[] array, T newItem);

        private static ByteString StorageGet(ByteString key)
        {
            return Storage.Get(Storage.CurrentContext, key);
        }

        private static ByteString StorageGet(byte[] key)
        {
            return Storage.Get(Storage.CurrentContext, key);
        }

        private static void StoragePut(ByteString key, ByteString value)
        {
            Storage.Put(Storage.CurrentContext, key, value);
        }


        private static void StoragePut(byte[] key, ByteString value)
        {
            Storage.Put(Storage.CurrentContext, key, value);
        }


        private static void StorageDelete(byte[] key)
        {
            Storage.Delete(Storage.CurrentContext, (ByteString)key);
        }

        private static Iterator StorageFind(byte[] prefix)
        {
            return Storage.Find(Storage.CurrentContext, prefix, FindOptions.RemovePrefix | FindOptions.DeserializeValues);
        }

    }
}
