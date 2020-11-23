using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.Managers;
using CoreGame;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        StartCoroutine(waitBeforeClick());
    }

    private IEnumerator waitBeforeClick()
    {
        yield return new WaitForSeconds(0.25f);
        GameManager.Instance.ChangeState(GameState.IN_GAME);
    }
    
    public void OnClickNextButton()
    {
        Destroy(GameManager.Instance.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OnClickRetryButton()
    {
        Destroy(GameManager.Instance.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
