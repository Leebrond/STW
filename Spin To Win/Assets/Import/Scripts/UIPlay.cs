using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlay : MonoBehaviour {

    [Header("Buttons")]
    public Button btnSpin;

    public Button btnIncBet;

    public Button btnDecBet;



    [Space]
    public int[] valueBet;

    public Text txtamountBet;

    public Text txtamountCoin;

    public int chosenBet;

    private int index;


	// Use this for initialization
	void Start () {
        index = 0;
        chosenBet = valueBet[index];
        txtamountBet.text = chosenBet.ToString();
        txtamountCoin.text = PlayerManager.instance.amountCoin.ToString();


        btnSpin.onClick.AddListener(Spin);
        btnDecBet.onClick.AddListener(DecreaseBet);
        btnIncBet.onClick.AddListener(IncreaseBet);
	}
    

    public void Spin()
    {
        Wheel.instance.SpinWheel();
    }


    public void IncreaseBet()
    {
        if(index>=0 && index < valueBet.Length - 1)
        {
            index++;
            chosenBet = valueBet[index];
            txtamountBet.text = chosenBet.ToString();
        }
    }

    public void DecreaseBet()
    {
        if (index > 0 && index < valueBet.Length)
        {
            index--;
            chosenBet = valueBet[index];
            txtamountBet.text = chosenBet.ToString();
        }
    }


    public void DisableButton()
    {
        btnSpin.interactable = false;
        btnIncBet.interactable = false;
        btnDecBet.interactable = false;
    }

    public void EnableButton()
    {
        btnSpin.interactable = true;
        btnIncBet.interactable = true;
        btnDecBet.interactable = true;
    }
	
}
