using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(FadeAndLoad(scene));
    }

    IEnumerator FadeAndLoad(string scene)
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(scene);
        yield return StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        Color c = fadeImage.color;

        while (c.a < 1)
        {
            c.a += Time.deltaTime * fadeSpeed;
            fadeImage.color = c;
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        Color c = fadeImage.color;

        while (c.a > 0)
        {
            c.a -= Time.deltaTime * fadeSpeed;
            fadeImage.color = c;
            yield return null;
        }
    }
}