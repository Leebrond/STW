using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour {

    public static GameConfig instance;
    
    public Sprite spWheel;

    public int countPrizes;

    public float degreePrize;

    public int[] timesPrize;

    

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

    public void SetConfig(WWW data)
    {
        string[] temp = data.text.Split(';');

        countPrizes = int.Parse(temp[0]);
        degreePrize = 360 / countPrizes;

        string[] tempPrize = temp[1].Split(',');

        timesPrize = new int[tempPrize.Length];

        for(int i = 0; i<tempPrize.Length; i++)
        {
            timesPrize[i] = int.Parse(tempPrize[i]);
        }
    }


    public void SetPic(WWW data)
    {
        Texture2D texture = new Texture2D(5, 5);
        data.LoadImageIntoTexture(texture);
        spWheel = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2);

        
    }
}
