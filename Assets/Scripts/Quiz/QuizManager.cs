using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] SoalLoader loader;
    [SerializeField] PertemuanSO[] pertemuan;
    [SerializeField] GameObject quiz, penjelasan;
    [SerializeField] Animator checkAnim, wrongAnim;
    int pertemuan_id = 0, soal_id = 0;

    public void Init()
    {
        loader.GetTextFromButton();
        loader.DisplayQuestion(pertemuan[pertemuan_id].soals[soal_id]);
        penjelasan.SetActive(false);
        quiz.SetActive(true);
    }

    public void CheckAnswer(bool isTrue)
    {
        soal_id++;
        if(isTrue) PlayCorrectAnim();
        else PlayWrongAnim();
    }

    public void NextDisplay()
    {
        penjelasan.SetActive(false);
        loader.DisplayQuestion(pertemuan[pertemuan_id].soals[soal_id]);
        quiz.SetActive(true);
    }

    public void PlayCorrectAnim()
    {
        checkAnim.gameObject.SetActive(true);
        checkAnim.Play("notif", 0, 0f);;
    }

    public void PlayWrongAnim()
    {
        wrongAnim.gameObject.SetActive(true);
        wrongAnim.Play("notif", 0, 0f);;
    }

    public void ShowPenjelasan()
    {
        quiz.SetActive(false);
        penjelasan.SetActive(true);
    }
}
