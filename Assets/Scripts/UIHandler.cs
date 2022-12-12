using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler: MonoBehaviour
{
    [SerializeField] GameHandler gameHandler;
    [SerializeField] GameObject eventSlot;
    //[SerializeField] TextMeshProUGUI title;
    private int turns;
    private double morale;
    private int funds;
    private double attention;
    private double operations;
    private int nextevent;
    private int thisevent;
    void Start(){
        turns = 20;
        morale = .8;
        funds = 100000;
        attention = .8;
        operations = .8;
        nextevent = 0;
        DisplayEvent();
        thisevent = Random.Range(1,10);
    }
    void DisplayEvent(){
        //title.SetText("Funds: $"+funds.ToString());
        eventSlot.transform.GetChild(0).GetComponent<Text>().text = 
        gameHandler.events[thisevent].eventText;
        eventSlot.transform.GetChild(1).GetComponent<Text>().text = gameHandler.events[thisevent].rightOption;
        eventSlot.transform.GetChild(2).GetComponent<Text>().text = gameHandler.events[thisevent].leftOption;
        eventSlot.transform.GetChild(3).GetComponent<Text>().text = "Funds: $"+funds.ToString();
        eventSlot.transform.GetChild(4).GetComponent<Text>().text = "Morale: "+morale.ToString();
        eventSlot.transform.GetChild(5).GetComponent<Text>().text = "Operations: "+ operations.ToString();
        eventSlot.transform.GetChild(6).GetComponent<Text>().text = "Attention: "+attention.ToString();
        eventSlot.transform.GetChild(7).GetComponent<Image>().sprite = gameHandler.events[thisevent].eventSprite;
    }
    void Update(){
        if (Input.GetKey("up")){ //Right
            morale = morale + gameHandler.events[thisevent].RmoraleVal;
            funds = funds + gameHandler.events[thisevent].RfundsVal;
            attention = attention + gameHandler.events[thisevent].RattentionVal;
            operations = operations + gameHandler.events[thisevent].RoperationsVal;
            nextevent = Random.Range(1,10);
            while (nextevent==thisevent){
                nextevent = Random.Range(1,10);
        }
            thisevent = nextevent;
            DisplayEvent();
            turns=turns+1;
            funds = funds +10000;
        }
        if (Input.GetKey("down")){ //Left
        morale = morale + gameHandler.events[thisevent].LmoraleVal;
            funds = funds + gameHandler.events[thisevent].LfundsVal;
            attention = attention + gameHandler.events[thisevent].LattentionVal;
            operations = operations + gameHandler.events[thisevent].LoperationsVal;
            nextevent = Random.Range(1,10);
        while (nextevent==thisevent){
            nextevent = Random.Range(1,10);
        }
        thisevent = nextevent;
        DisplayEvent();
        turns=turns+1;
        funds = funds + 10000;
        }
        if (turns>20 || attention <= 0 || operations <= 0 || funds <=0 || morale <=0){
            eventSlot.transform.GetChild(0).GetComponent<Text>().text = "GAME OVER";
            eventSlot.transform.GetChild(1).GetComponent<Text>().text = "GAME OVER";
        eventSlot.transform.GetChild(2).GetComponent<Text>().text = "GAME OVER";
        eventSlot.transform.GetChild(3).GetComponent<Text>().text = "GAME OVER";
        eventSlot.transform.GetChild(4).GetComponent<Text>().text = "GAME OVER";
        eventSlot.transform.GetChild(5).GetComponent<Text>().text = "GAME OVER";
        eventSlot.transform.GetChild(6).GetComponent<Text>().text = "GAME OVER";
        }
        if (morale <= .2){
            thisevent = 8;
        }
        if (attention    >=10 ){
            thisevent = 9;
        }
        
    }
}
