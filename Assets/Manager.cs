using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoralisUnity;
using MoralisUnity.Web3Api.Models;
using System;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text walletAddress;
    public GameObject btnPrefab;
    public GameObject btnParent;
    public static string selectedContract;
    public static string selectedTokenId;
    public static string selectedSymbol;


    void Start()
    {
        Moralis.Start();
        walletAddress.text = "Loading NFTs...";
        GetNFT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void GetNFT(){
        
        try{
            NftOwnerCollection polygonNFTs = await Moralis.Web3Api.Account.GetNFTs(PlayerPrefs.GetString("Account").ToLower(), ChainList.mumbai);
            List<NftOwner> nftOwners = polygonNFTs.Result;
            walletAddress.color = Color.green;
            walletAddress.text = PlayerPrefs.GetString("Account");

            foreach (var nftOwner in nftOwners){

            GameObject newBtn = GameObject.Instantiate(btnPrefab,btnParent.transform);
                newBtn.GetComponentInChildren<Text>().text = nftOwner.Symbol + " id: " + nftOwner.TokenId ;
                newBtn.GetComponent<Button>().onClick.AddListener(()=>TaskOnClick(nftOwner.TokenAddress, nftOwner.TokenId,nftOwner.Symbol));
            }
            
        }catch(Exception e){
            walletAddress.color = Color.red;
            walletAddress.text =e.Message;
            }

    }

    void TaskOnClick(string address, string id, string symbol)
    {
        selectedContract = address;
        selectedTokenId = id;
        selectedSymbol = symbol;
    }


}
