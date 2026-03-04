using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField] SoalLoader loader;
    [SerializeField] PertemuanSO[] pertemuan;
    [SerializeField] GameObject quiz, penjelasan;
    int pertemuan_id = 0, soal_id = 0;

    void Start()
    {
        Init();
    }

    void Init()
    {
        penjelasan.SetActive(false);
        quiz.SetActive(true);
        loader.GetTextFromButton();
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
        
    }

    public void PlayWrongAnim()
    {
        
    }
}
