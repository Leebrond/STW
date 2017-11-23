using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WWWLogin : MonoBehaviour {

    public GameObject panelLogin;

    public GameObject panelLobby;

    public InputField inputUsername;

    public InputField inputPassword;

    public Text txtInfo;

    

    public void Login()
    {
        if (string.IsNullOrEmpty(inputUsername.text) || string.IsNullOrEmpty(inputPassword.text))
        {
            txtInfo.text = "Input username and password ";
           // return;
        }

        StartCoroutine(GetPlayerData());
    }


    private IEnumerator GetPlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", "kevin");
        form.AddField("passwordPost", "kevin");

        WWW www = new WWW(DB.instance.URL + "user.php", form);

        yield return www;

        Debug.Log(www.text);

        string[] temp;

        temp = www.text.Split(';');

        if (temp[0] == "\nLogin success ")
        {
            panelLobby.SetActive(true);
            panelLogin.SetActive(false);
        }

        PlayerManager.instance.amountCoin = int.Parse(temp[1]);
    }
}
