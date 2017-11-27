using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class Wheel : MonoBehaviour
{
    public static Wheel instance;

   // public int countPrizes = 24;

    //public float degreePrize;

    public float[] spinAngle;

    public UIPlay uiPlay;

    private Prize prize;
    
    private bool isSpinning;

    private float startAngle;

    private float finishAngle;
    
    private float maxLerpRotationTime;

    private float currentLerpRotationTime;

    private float arrowSpeed;
    
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GetComponent<Image>().sprite = GameConfig.instance.spWheel;

        prize = GetComponent<Prize>();

        spinAngle = new float[GameConfig.instance.countPrizes];
        float a = 0;

        for (int i = 0; i < GameConfig.instance.countPrizes; i++)
        {
            //Debug.Log(a);
            spinAngle[i] = a;
            a += GameConfig.instance.degreePrize;
        }

        FindObjectOfType<Prize>().SetPrize();
    }


    void FixedUpdate()
    {
        if (isSpinning)
        {
            if (currentLerpRotationTime <= 3f)
            {
                currentLerpRotationTime += Time.deltaTime;
            }
            else if (currentLerpRotationTime > 3f && currentLerpRotationTime < 5f)
            {
                currentLerpRotationTime += Time.deltaTime / 2.5f;
            }
            else if (currentLerpRotationTime > 5f && currentLerpRotationTime < 6f)
            {
                currentLerpRotationTime += Time.deltaTime / 4.5f;
            }
            else
            {
                currentLerpRotationTime += Time.deltaTime / 6f;
            }


            if (currentLerpRotationTime > maxLerpRotationTime || this.transform.eulerAngles.z == finishAngle)
            {
                currentLerpRotationTime = maxLerpRotationTime;

                //mainSound.PlayOneShot(mainSound.clip);

                isSpinning = false;

                startAngle = finishAngle % 360;
                Debug.Log("Start Angle : " + startAngle);

                //  GiveAwardByAngle();
                GiveAward();

                uiPlay.EnableButton();
               
            }

            float t = currentLerpRotationTime / maxLerpRotationTime;

            t = t * t * t * (t * (6f * t - 15f) + 10f);

            float angle = Mathf.Lerp(startAngle, finishAngle, t);

            this.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }



    private void GiveAward()
    {
        for(int i = 0; i<GameConfig.instance.countPrizes; i++)
        {
            float a = -i * GameConfig.instance.degreePrize;

            if( a == startAngle)
            {
                PlayerManager.instance.amountCoin += (GameConfig.instance.timesPrize[i] * uiPlay.chosenBet);
                uiPlay.txtamountCoin.text = PlayerManager.instance.amountCoin.ToString();
                Debug.Log(i);
                return;
            }
        }

    }


    private void RewardCoins(int coins)
    {
        Debug.Log("Win : " + coins.ToString() + " coins");
    }


   /* private void GiveAwardByAngle()
    {
        // Here you can set up rewards for every sector of wheel
        switch ((int)startAngle)
        {
            case 0:
                RewardCoins(1000);
                break;
            case -330:
                RewardCoins(200);
                break;
            case -300:
                RewardCoins(100);
                break;
            case -270:
                RewardCoins(500);
                break;
            case -240:
                RewardCoins(300);
                break;
            case -210:
                RewardCoins(100);
                break;
            case -180:
                RewardCoins(900);
                break;
            case -150:
                RewardCoins(200);
                break;
            case -120:
                RewardCoins(100);
                break;
            case -90:
                RewardCoins(700);
                break;
            case -60:
                RewardCoins(300);
                break;
            case -30:
                RewardCoins(100);
                break;
            default:
                RewardCoins(300);
                break;
        }
    } */

   


    public void SpinWheel()
    {

        uiPlay.DisableButton();

        currentLerpRotationTime = 0f;

        maxLerpRotationTime = 7f;

        int fullCircle = 12;

        float randomFinishAngle = spinAngle[UnityEngine.Random.Range(0, spinAngle.Length)];

        Debug.Log(randomFinishAngle);

        finishAngle = -(fullCircle * 360 + randomFinishAngle);
        Debug.Log("Finish Angle : " + finishAngle);
        isSpinning = true;
    }




}
