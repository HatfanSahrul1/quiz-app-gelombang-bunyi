using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SoalLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soalText, penjelasan, jawaban;
    [SerializeField] Button aButton, bButton, cButton, dButton, eButton;
    TextMeshProUGUI aOption, bOption, cOption, dOption, eOption;

    SoalSO.CorrectAnswer answer;

    [SerializeField] UnityEvent onCorrect, onWrong;

    public void GetTextFromButton()
    {
        aOption = aButton.GetComponentInChildren<TextMeshProUGUI>();
        bOption = bButton.GetComponentInChildren<TextMeshProUGUI>();
        cOption = cButton.GetComponentInChildren<TextMeshProUGUI>();
        dOption = dButton.GetComponentInChildren<TextMeshProUGUI>();
        eOption = eButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DisplayQuestion(SoalSO soal)
    {
        answer = soal.correct;
        
        jawaban.text = "Jawaban : " + GetStringAnswer(answer);
        soalText.text = soal.soal;

        aOption.text = soal.a;
        bOption.text = soal.b;
        cOption.text = soal.c;
        dOption.text = soal.d;
        eOption.text = soal.e;

        penjelasan.text = soal.penjelasan;

        soalText.richText = true;
        penjelasan.richText = true;
        aOption.richText = true;
        bOption.richText = true;
        cOption.richText = true;
        dOption.richText = true;
        eOption.richText = true;

        aButton.onClick.AddListener(() => Answer("A"));
        bButton.onClick.AddListener(() => Answer("B"));
        cButton.onClick.AddListener(() => Answer("C"));
        dButton.onClick.AddListener(() => Answer("D"));
        eButton.onClick.AddListener(() => Answer("E"));
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

    string GetStringAnswer(SoalSO.CorrectAnswer ans)
    {
        if(ans == SoalSO.CorrectAnswer.A) return "A";
        if(ans == SoalSO.CorrectAnswer.B) return "B";
        if(ans == SoalSO.CorrectAnswer.C) return "C";
        if(ans == SoalSO.CorrectAnswer.D) return "D";
        if(ans == SoalSO.CorrectAnswer.E) return "E";
        else return "none";
    }
}