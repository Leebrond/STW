using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour {

    public Image imgPic;

    public Image imgPic2;
	// Use this for initialization
	void Start () {
        StartCoroutine(GetLength());
	}

    public void LoadPic()
    {
        StartCoroutine(GetPic());
    }


    private IEnumerator GetLength()
    {
        WWW www = new WWW(DB.instance.URL + "length.php");

        yield return www;

        Debug.Log(www.text);

        int length = int.Parse(www.text);
    }


    private IEnumerator GetPic()
    {
        WWW www = new WWW(DB.instance.URL + "stw.php");

        yield return www;

        Debug.Log(www.text);

        string[] temp = www.text.Split(';');

        Debug.Log(temp.Length);
        string[] temp2;

       
        for(int i= 0; i<temp.Length; i++)
        {
            temp2 = temp[0].Split(',');
            Debug.Log(temp2[2]);
            Texture2D texture = new Texture2D(5, 5);
            www.LoadImageIntoTexture(texture);

            if(i == 0)
            {
                imgPic.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2);
            } else
            {
                imgPic2.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2);
            }
        }

     /*   Texture2D texture = new Texture2D(5, 5);
        www.LoadImageIntoTexture(texture);
        imgPic.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2);*/
    }
}
