# CommitteeInfoContract

This contract is used to add candidates relevant information, such as the candidate's github, social media account, and description.

## Contract Hash

* **mainnet:** 0xb776afb6ad0c11565e70f8ee1dd898da43e51be1

* **testnet4:** 0xe922910b49305ad00240cdd104fda6574e2f4d38

* **testnet5:** 0x6177bfcef0f51b5dd21b183ff89e301b9c66d71c


## Method Name: **setInfo**

### Description

Updates the committee information

### Parameters

| ParameterName | Type | Description |
| ---- | ---- | ---- |
| sender | Hash160 | Committee address. Signature is required |
| name | String | Committee name |
| location | String | Committee location |
| website | String | Committee website url |
| email | String | Committee email |
| github | String | Committee github account |
| telegram | String | Committee telegram |
| twitter | String | Committee twitter |
| description | String | Committee description |
| logo | String | Committee logo's FS ID |

### Invoking by Neo-GUI

In the Neo-GUI Invoke Contract page, enter the contract script hash and select the invoke method to `setInfo`. Then fill in the information fields that appears. In `Cosigners`, the sender's signature is required.

![001](https://user-images.githubusercontent.com/7391819/125911981-89c12f1d-2a12-4c06-9fff-0454eaad63ff.png)
![002](https://user-images.githubusercontent.com/7391819/125911998-32a2cfc0-abee-4a87-99a3-a6ea7f81d87a.png)
![003](https://user-images.githubusercontent.com/7391819/125912023-04494f31-0ace-47ea-a5d5-98660218d64f.png)

### Invoking by Neo-CLI

> [!Note]
>
> - If you choose invoking contract by CLI, you can't add blank in a single param. Otherwise, it will be regarded as two param. Please try `ByteArray` as value type for any blank needed situation.
> - Example: {"type":"ByteArray","value":"QlVJTERJTkcgQkxPQ0tTIEZPUiBUSEUgTkVYVCBHRU5FUkFUSU9OIElOVEVSTkVU"}
> - Official converter page: https://neo.org/converter/index (try to input String and get Base64 encoding)
> - For `Logo` param, please use [FS service](https://filesend.ngd.network/) here to upload logo file of your institution and copy the **objectId** to the `Logo` param. We recommend use a square logo image (e.g. 100x100)


Use the CLI command [invoke](https://docs.neo.org/docs/en-us/node/cli/cli.html#invoke):

`invoke <scriptHash> <operation> [contractParameters=null] [sender=null] [signerAccounts=null][maxGas]`


**contractParameters cannot contain whitespace, please use "ByteArray" type and base64 string value to input long string.**
  
#### Example

```
invoke 0xe922910b49305ad00240cdd104fda6574e2f4d38 setInfo [{"type":"Hash160","value":"0x429688538c267d5da7a03fbe7b8e4cf45d6e9826"},{"type":"String","value":"MyName"},{"type":"String","value":"MyLocation"},{"type":"String","value":"http://mysite.com"},{"type":"String","value":"myemail@mail.com"},{"type":"String","value":"mygithub"},{"type":"String","value":"mytelegram"},{"type":"String","value":"mytwitter"},{"type":"ByteArray","value":"VGhpcyBpcyBhbiBleGFtcGxlLg=="},{"type":"String","value":"mylogoID"}] NPS3U9PduobRCai5ZUdK2P3Y8RjwzMVfSg NPS3U9PduobRCai5ZUdK2P3Y8RjwzMVfSg


```

------
