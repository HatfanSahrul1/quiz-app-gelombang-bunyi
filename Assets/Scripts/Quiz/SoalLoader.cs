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
        if(aButton) aButton.onClick.AddListener(() => Answer("A"));
        if(bButton) bButton.onClick.AddListener(() => Answer("B"));
        if(cButton) cButton.onClick.AddListener(() => Answer("C"));
        if(dButton) dButton.onClick.AddListener(() => Answer("D"));
        if(eButton) eButton.onClick.AddListener(() => Answer("E"));
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
            aOption.SetNativeSize();
        }
        if(bOption)
        {
            bOption.sprite = soal.b;
            bOption.SetNativeSize();
        }
        if(cOption)
        {
            cOption.sprite = soal.c;
            cOption.SetNativeSize();
        }
        if(dOption)
        {
            dOption.sprite = soal.d;
            dOption.SetNativeSize();
        }
        if(eOption)
        {
            eOption.sprite = soal.e;
            eOption.SetNativeSize();
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