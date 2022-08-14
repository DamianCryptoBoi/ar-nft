using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFTItem : MonoBehaviour
{
    public TextMesh Symbol;
    // Start is called before the first frame update
    void Start()
    {
        Symbol.text = Manager.selectedSymbol + " ID: " + Manager.selectedTokenId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
