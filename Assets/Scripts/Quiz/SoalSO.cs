using UnityEngine;

[CreateAssetMenu(fileName = "NewSoal", menuName = "QuizApp/Soal")]
public class SoalSO : ScriptableObject
{
    public enum CorrectAnswer
    {
        A,
        B,
        C,
        D,
        E
    }

    [TextArea]
    public string soal = "Lorem Ipsum", a, b, c, d, e;
    public CorrectAnswer correct;
    
    [TextArea]
    public string penjelasan;
}
