using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {

    public GameObject prefPoint;

    private Transform tfPoint;
    

    public void SetPoint()
    {
        tfPoint = transform.Find("Point");
        tfPoint.GetComponent<RadialLayout>().MinAngle = GameConfig.instance.degreePrize;
        tfPoint.GetComponent<RadialLayout>().StartAngle = GameConfig.instance.degreePrize / 2;

        for(int i = 0; i<GameConfig.instance.countPrizes; i++)
        {
            GameObject temp = Instantiate(prefPoint, transform.position, Quaternion.identity, tfPoint);
        }
    }

}
