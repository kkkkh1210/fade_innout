using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FadeTextUI : MonoBehaviour
{
    public Image blackPanel;
    public TMP_Text centerText;

    public float fadeInTime = 2.2f;
    public float holdTime = 1.5f;
    public float fadeOutTime = 0.8f;

    public void ShowFadeText(string text)
    {
        centerText.text = text;
        StopAllCoroutines();
        StartCoroutine(Sequence());
    }

   IEnumerator Sequence()
{
    yield return StartCoroutine(Fade(0f, 1f, fadeInTime));
    yield return new WaitForSeconds(holdTime);
    yield return StartCoroutine(Fade(1f, 0f, fadeOutTime));
}


    IEnumerator Fade(float start, float end, float duration)
    {
        float t = 0f;
        Color pc = blackPanel.color;
        Color tc = centerText.color;

        while (t < duration)
        {
            float a = Mathf.Lerp(start, end, t / duration);
            float textAlpha = Mathf.Min(a, 0.75f);

            pc.a = a;
            tc.a = textAlpha;
            blackPanel.color = pc;
            centerText.color = tc;

            t += Time.deltaTime;
            yield return null;
        }

        pc.a = end;
        tc.a = end;
        blackPanel.color = pc;
        centerText.color = tc;
    }
    
}
