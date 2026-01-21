using UnityEngine;

public class GameStart : MonoBehaviour
{
    public FadeTextUI 페이드UI;

    void Start()
    {
        페이드UI.ShowFadeText("DAY 1");
    }
}
