﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DB : MonoBehaviour
{
    public static DB instance;

    public string URL;


    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    
  

    public IEnumerator UpdateBalance(int times, int bet)
    {
        Debug.Log("UpdateBalance");
        WWWForm form = new WWWForm();
        form.AddField("timesPost", times);
        form.AddField("betPost", bet);
        form.AddField("usernamePost", PlayerManager.instance.playerName);

        WWW www = new WWW(URL + "coin.php", form);

        yield return www;

        Debug.Log(www.text);

        PlayerManager.instance.amountCoin = int.Parse(www.text);
    }

}
    
