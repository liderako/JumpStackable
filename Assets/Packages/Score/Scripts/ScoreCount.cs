using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] Text _score;
    [SerializeField] private Text _scoreOutline;
    public void SetScore(int i)
    {
        _score.text = "+" + i;
        _scoreOutline.text = "+" + i;
        gameObject.SetActive(true);
        Destroy(gameObject, 1.5f);
    }
}
