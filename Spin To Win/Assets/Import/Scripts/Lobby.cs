using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour {

    public Text txtPlayername;

    public Text txtCoin;

    public GameObject menuAddCoin;

	void Start () {

        txtPlayername.text = PlayerManager.instance.playerName;
        txtCoin.text = PlayerManager.instance.amountCoin.ToString();
	}

   
}
