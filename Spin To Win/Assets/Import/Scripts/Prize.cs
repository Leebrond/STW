﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prize : MonoBehaviour {

    public int[] timesPrize;

    public GameObject prefPrize;

    public Text[] txtPrize;

    private Transform tfPrize;




    public void SetPrize()
    {
        txtPrize = new Text[Wheel.instance.countPrizes];

        tfPrize = transform.GetChild(0);

        GameObject temp;

        float startAngle = 0;

        //float addDegree = 360 / Wheel.instance.countPrizes;

        tfPrize.GetComponent<RadialLayout>().MinAngle = 360 - Wheel.instance.degreePrize;

        for (int i = 0; i < Wheel.instance.countPrizes; i++)
        {
            temp = Instantiate(prefPrize, transform.position, Quaternion.identity, tfPrize);
            temp.transform.localEulerAngles = new Vector3(0, 0, startAngle);
            //temp.GetComponent<Text>().text = startAngle.ToString()
            temp.GetComponent<Text>().text = timesPrize[i].ToString();
            temp.name = startAngle.ToString();
            txtPrize[i] = temp.GetComponent<Text>();
            startAngle -= Wheel.instance.degreePrize;
        }
    }
	
	
}
