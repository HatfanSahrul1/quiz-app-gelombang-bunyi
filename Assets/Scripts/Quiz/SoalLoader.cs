using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class SoalLoader : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] Image soalText, penjelasan;
    [SerializeField] Button aButton, bButton, cButton, dButton, eButton;
    
    Image aOption, bOption, cOption, dOption, eOption;

    SoalSO.CorrectAnswer answer;
    [SerializeField] UnityEvent onCorrect, onWrong;

    void Awake()
    {
        GetTextFromButton();
        SetupButtonListeners();
    }

    public void GetTextFromButton()
    {
        if(aButton) aOption = aButton.GetComponent<Image>();
        if(bButton) bOption = bButton.GetComponent<Image>();
        if(cButton) cOption = cButton.GetComponent<Image>();
        if(dButton) dOption = dButton.GetComponent<Image>();
        if(eButton) eOption = eButton.GetComponent<Image>();
    }

    void SetupButtonListeners()
    {
        if(aButton)
        { 
            aButton.onClick.AddListener(() => Answer("A"));
            aButton.onClick.AddListener(() => CheckButton(aButton));
        }
        if(bButton)
        { 
            bButton.onClick.AddListener(() => Answer("B"));
            bButton.onClick.AddListener(() => CheckButton(bButton));
        }
        if(cButton)
        { 
            cButton.onClick.AddListener(() => Answer("C"));
            cButton.onClick.AddListener(() => CheckButton(cButton));
        }
        if(dButton)
        { 
            dButton.onClick.AddListener(() => Answer("D"));
            dButton.onClick.AddListener(() => CheckButton(dButton));
        }
        if(eButton)
        { 
            eButton.onClick.AddListener(() => Answer("E"));
            eButton.onClick.AddListener(() => CheckButton(eButton));
        }
    }

    public void DisplayQuestion(SoalSO soal)
    {
        if (soal == null) return;

        answer = soal.correct;
        
        soalText.sprite = soal.soal;
        penjelasan.sprite = soal.penjelasan;
        penjelasan.SetNativeSize();
        
        if(aOption)
        {
            aOption.sprite = soal.a;
            aOption.gameObject.SetActive(true);
            aOption.SetNativeSize();
        }
        if(bOption)
        {
            bOption.sprite = soal.b;
            bOption.gameObject.SetActive(true);
            bOption.SetNativeSize();
        }
        if(cOption)
        {
            cOption.sprite = soal.c;
            cOption.gameObject.SetActive(true);
            cOption.SetNativeSize();
        }
        if(dOption)
        {
            dOption.sprite = soal.d;
            dOption.gameObject.SetActive(true);
            dOption.SetNativeSize();
        }
        if(eOption)
        {
            eOption.sprite = soal.e;
            eOption.gameObject.SetActive(true);
            eOption.SetNativeSize();
        }
    }

    public void CheckButton(Button btn)
    {
        Button[] buttons = {aButton, bButton, cButton, dButton, eButton};

        foreach (Button item in buttons)
        {
            if(item != btn) item.gameObject.SetActive(false);
        }
    }

    public void Answer(string asw)
    {
        if(GetAnswer(asw) == answer) onCorrect?.Invoke();
        else onWrong?.Invoke();
    }

    SoalSO.CorrectAnswer GetAnswer(string asw)
    {
        if(asw == "A") return SoalSO.CorrectAnswer.A;
        if(asw == "B") return SoalSO.CorrectAnswer.B;
        if(asw == "C") return SoalSO.CorrectAnswer.C;
        if(asw == "D") return SoalSO.CorrectAnswer.D;
        if(asw == "E") return SoalSO.CorrectAnswer.E;
        else return SoalSO.CorrectAnswer.E;
    }
}