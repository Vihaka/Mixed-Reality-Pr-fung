using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;

public class StartTheGame : MonoBehaviour, IMixedRealityPointerHandler
{
    public GameObject objectGeneratorGameObject;
    public GameObject startGameObject;
    public GameObject stopGameObject;
    public ScoreCounter scoreCounter; // Reference to ScoreCounter
    public Countdown countdown; // Reference to Countdown

    public bool isGameRunning = false;

    void Start()
    {
        objectGeneratorGameObject.SetActive(false);
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (eventData.Pointer.Result.CurrentPointerTarget == startGameObject && !isGameRunning)
        {
            StartCoroutine(StartGameWithDelay(3f));
        }
        else if (eventData.Pointer.Result.CurrentPointerTarget == stopGameObject && isGameRunning)
        {
            StopGame();
        }
    }

    IEnumerator StartGameWithDelay(float delay)
    {
        countdown.StartCountdown();
        yield return new WaitForSeconds(delay);
        objectGeneratorGameObject.SetActive(true);
        isGameRunning = true;
    }

    void StopGame()
    {
        objectGeneratorGameObject.SetActive(false);
        var objectGenerator = objectGeneratorGameObject.GetComponent<ObjectGenerator>();
        if (objectGenerator != null)
        {
            objectGenerator.DestroyGeneratedObjects();
        }
        isGameRunning = false;
        scoreCounter.ResetScore(); // Reset score
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData) { }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) { }
    public void OnPointerUp(MixedRealityPointerEventData eventData) { }
}