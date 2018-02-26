using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FancySplashScreen : MonoBehaviour
{
    public Image logo;

    public Color spritecolor = Color.white;
    public float fadeintime;
    public float hangtime;
    public float fadeouttime;
    public float endhangtime;
    int currentstage;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(splashscreen());
    }

    void MainMenu()
    {
        StopCoroutine(splashscreen());
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    IEnumerator splashscreen()
    {
        float fade = 0f;
        float startTime;
        while (true)
        {
            startTime = Time.time;
            while (fade < 1f)
            {
                fade = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeintime);
                spritecolor.a = fade;
                logo.color = spritecolor;
                yield return null;
            }
            fade = 1f;
            spritecolor.a = fade;
            logo.color = spritecolor;
            yield return new WaitForSeconds(hangtime);

            startTime = Time.time;
            while (fade > 0f)
            {
                fade = Mathf.Lerp(1f, 0f, (Time.time - startTime) / fadeouttime);
                spritecolor.a = fade;
                logo.color = spritecolor;
                yield return null;
            }
            fade = 0f;
            spritecolor.a = fade;
            logo.color = spritecolor;
            yield return new WaitForSeconds(endhangtime);
            MainMenu();
        }
    }
}
