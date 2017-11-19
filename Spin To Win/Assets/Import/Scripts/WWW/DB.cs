using System.Collections;
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


    public void Login(string username, string password)
    {
        StartCoroutine(GetPlayerData(username, password));
    }


    private IEnumerator GetPlayerData(string username, string password)
    {
        
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(URL + "user.php", form);

        yield return www;

        string[] temp;

        temp = www.text.Split(';');

        if (temp[0] == "\nLogin success ")
        {
            Home.isLogin = true;
        }

        PlayerManager.instance.amountCoin = int.Parse(temp[1]);
        
        Debug.Log(www.text);
    }


   
    

}
    
