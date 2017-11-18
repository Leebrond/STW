using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;

    public int amountCoin = 1000;

    void Awake()
    {
       if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else if( instance != this)
        {
            Destroy(gameObject);
        }
    }




    // Update is called once per frame
    void Update () {
		
	}
}
