using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BlackoutManager : MonoBehaviour
{
    [SerializeField] private TipsTriggerBlackout triggerBlackout;
    [SerializeField] private GameObject rawImage;
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private int scene;
    [SerializeField] private Image imageText;
    [SerializeField] private Sprite image;
    private void Update()
    {
        if(triggerBlackout.counter >= 3)
        {
            StartCoroutine(TimerCastScene());
        }
    }
    public void Func()
    {
        StartCoroutine(TimerWind());
    }

    IEnumerator TimerWind()
    {
        yield return new WaitForSeconds(4f);
        triggerBlackout.gameObject.SetActive(true);
    }
    IEnumerator TimerCastScene()
    {
        yield return new WaitForSeconds(5f);
        rawImage.SetActive(true);
        videoPlayer.SetActive(true);
        yield return new WaitForSeconds(4f);
        imageText.sprite = image;
        SceneManager.LoadScene(scene);
        // кастсцена
        //перенос на следующую локацию
    }
}
