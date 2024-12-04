using UnityEngine;
using TMPro;
using System.Collections;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshPro countdownText;
    [SerializeField] private int countdownTime = 3;
    [SerializeField] private GameObject gameObjectToActivate;

    private Coroutine countdownCoroutine;

    void Start()
    {
        // Optionally start the countdown immediately
        // StartCountdown();
    }

    public void StartCountdown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        countdownCoroutine = StartCoroutine(StartCountdownCoroutine());
    }

    private IEnumerator StartCountdownCoroutine()
    {
        gameObjectToActivate.SetActive(true);
        int currentTime = countdownTime;
        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        gameObjectToActivate.SetActive(false);
    }
}