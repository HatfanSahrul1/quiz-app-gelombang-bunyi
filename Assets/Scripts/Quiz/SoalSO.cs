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

    public Sprite soal, a, b, c, d, e;
    public CorrectAnswer correct;
    
    public Sprite penjelasan;
}
