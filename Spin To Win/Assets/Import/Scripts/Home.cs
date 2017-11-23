using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour {

    public static bool isLogin;

    public GameObject panelLogin;

    public GameObject panelLobby;

    public InputField inputUsername;

    public InputField inputPassword;

    public Text txtInfo;


    void Start()
    {
        txtInfo.text = "Welcome";
    }



    void Update()
    {
        if (isLogin)
        {
            // panelLobby.SetActive(true);
            // panelLogin.SetActive(false);
            Debug.Log("loggedin");
            SceneManager.LoadScene(1);
            isLogin = false;
        }
    }


    public void CheckLogin()
    {
        if (string.IsNullOrEmpty(inputUsername.text) || string.IsNullOrEmpty(inputUsername.text))
        {
            txtInfo.text= "Input username and password";
            return;
        }

     //   DB.instance.Login(inputUsername.text, inputPassword.text);
    }

    
	
	
}
