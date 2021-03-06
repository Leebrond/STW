﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prize : MonoBehaviour {

    public GameObject prefPrize;

    public Text[] txtPrize;

    private Transform tfPrize;

    
    public void SetPrize()
    {
        txtPrize = new Text[GameConfig.instance.countPrizes];

        tfPrize = transform.GetChild(0);

        GameObject temp;

        float startAngle = 0;

        tfPrize.GetComponent<RadialLayout>().MinAngle = 360 - GameConfig.instance.degreePrize;

        for (int i = 0; i < GameConfig.instance.countPrizes; i++)
        {
            temp = Instantiate(prefPrize, transform.position, Quaternion.identity, tfPrize);
            temp.transform.localEulerAngles = new Vector3(0, 0, startAngle);
            temp.GetComponent<Text>().text = GameConfig.instance.timesPrize[i].ToString();
            temp.name = startAngle.ToString();
            txtPrize[i] = temp.GetComponent<Text>();
            startAngle -= GameConfig.instance.degreePrize;
        }
    }
}
