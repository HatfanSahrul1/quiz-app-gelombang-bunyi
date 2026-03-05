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
    [SerializeField] TextMeshProUGUI soalText, penjelasan, jawaban;
    [SerializeField] Button aButton, bButton, cButton, dButton, eButton;
    
    // Cache referensi text tombol agar tidak perlu GetComponent berulang
    TextMeshProUGUI aOption, bOption, cOption, dOption, eOption;

    SoalSO.CorrectAnswer answer;
    [SerializeField] UnityEvent onCorrect, onWrong;

    // ✅ 1. Inisialisasi otomatis saat game mulai
    void Awake()
    {
        GetTextFromButton();
        SetupButtonListeners();
    }

    public void GetTextFromButton()
    {
        if(aButton) aOption = aButton.GetComponentInChildren<TextMeshProUGUI>();
        if(bButton) bOption = bButton.GetComponentInChildren<TextMeshProUGUI>();
        if(cButton) cOption = cButton.GetComponentInChildren<TextMeshProUGUI>();
        if(dButton) dOption = dButton.GetComponentInChildren<TextMeshProUGUI>();
        if(eButton) eOption = eButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    // ✅ 2. Setup Listener HANYA SEKALI (Mencegah bug klik ganda)
    void SetupButtonListeners()
    {
        if(aButton) aButton.onClick.AddListener(() => Answer("A"));
        if(bButton) bButton.onClick.AddListener(() => Answer("B"));
        if(cButton) cButton.onClick.AddListener(() => Answer("C"));
        if(dButton) dButton.onClick.AddListener(() => Answer("D"));
        if(eButton) eButton.onClick.AddListener(() => Answer("E"));
    }

    // ✅ 3. Fungsi Pembersih Karakter Tersembunyi
    string CleanText(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        
        // Hapus karakter problematic (Japanese brackets, zero-width, dll)
        input = input.Replace("\u3016", "")
                     .Replace("\u3017", "")
                     .Replace("\u200B", "")
                     .Replace("\uFEFF", "")
                     .Replace("\u00A0", " ");
        
        // Rapikan spasi ganda
        input = Regex.Replace(input, @"\s+", " ");
        
        return input.Trim();
    }

    // ✅ 4. Fungsi Parser Unicode Escape (Jika Anda ketik \u221A di Inspector)
    string ParseUnicodeEscape(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        
        return Regex.Replace(
            input,
            @"\\u([0-9A-Fa-f]{4})",
            m => ((char)int.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber)).ToString()
        );
    }

    public void DisplayQuestion(SoalSO soal)
    {
        if (soal == null) return;

        answer = soal.correct;
        
        // ✅ 5. Apply Clean & Parse ke SEMUA text
        jawaban.text = "Jawaban : " + GetStringAnswer(answer);
        
        soalText.text = ParseUnicodeEscape(CleanText(soal.soal));
        penjelasan.text = ParseUnicodeEscape(CleanText(soal.penjelasan));
        
        if(aOption) aOption.text = ParseUnicodeEscape(CleanText(soal.a));
        if(bOption) bOption.text = ParseUnicodeEscape(CleanText(soal.b));
        if(cOption) cOption.text = ParseUnicodeEscape(CleanText(soal.c));
        if(dOption) dOption.text = ParseUnicodeEscape(CleanText(soal.d));
        if(eOption) eOption.text = ParseUnicodeEscape(CleanText(soal.e));

        // Enable rich text
        soalText.richText = true;
        penjelasan.richText = true;
        if(aOption) aOption.richText = true;
        if(bOption) bOption.richText = true;
        if(cOption) cOption.richText = true;
        if(dOption) dOption.richText = true;
        if(eOption) eOption.richText = true;
        
        // Force update layout agar text langsung muncul benar
        LayoutRebuilder.ForceRebuildLayoutImmediate(soalText.rectTransform);
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