﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public class Data
    {
        public Mark Mark;
        public int Number;
    }

    public enum Mark
    {
        Heart,
        Diamond,
        Spade,
        Crub,
    }

    public bool IsReverse = false;
    [Range(1, 13)]
    public int Number = 1;
    public Mark CurrentMark = Mark.Heart;

    public void SetCard(int number,Mark mark,bool isReverse)
    {
        Number = Mathf.Clamp(number, 2, 14);
        CurrentMark = mark;
        IsReverse = isReverse;

        var image = GetComponent<Image>();
        if (IsReverse)
        {
            image.color = Color.black;
        }
        else
        {
            image.color = Color.white;
        }
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(!IsReverse);
        }

        var markObj = transform.Find("Mark");
        var markText = markObj.GetComponent<Text>();
        switch (CurrentMark)
        {
            case Mark.Heart:
                markText.text = "❤️";
                markText.color = Color.red;
                break;
            case Mark.Diamond:
                markText.text = "♦️";
                markText.color = Color.red;
                break;
            case Mark.Spade:
                markText.text = "♠️";
                markText.color = Color.black;
                break;
            case Mark.Crub:
                markText.text = "♣️";
                markText.color = Color.black;
                break;
        }

        //数字に合わせてGameObjectを設定する
        var numberObj = transform.Find("NumberText");
        var numberText = numberObj.GetComponent<Text>();
        if (Number == 14)
        {
            numberText.text = "A";
        }
        else if (Number == 11)
        {
            numberText.text = "J";
        }
        else if (Number == 12)
        {
            numberText.text = "Q";
        }
        else if (Number == 13)
        {
            numberText.text = "K";
        }
        else
        {
            numberText.text = Number.ToString();
        }
    }

    private void OnValidate()
    {
        SetCard(Number, CurrentMark, IsReverse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
