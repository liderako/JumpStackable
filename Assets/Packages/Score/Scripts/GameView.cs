using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] ScoreCount _countPr;
    [SerializeField] Text _score;
    [SerializeField] private GameObject _wow;
    [SerializeField] private GameObject _perfect;
    [SerializeField] private GameObject _omg;

    public enum Title
    {
        Wow,
        Perfect,
        Omg
    }

    public void AddScore(int score, int i)
    {
        CreateRandomCount(i);
        _score.text = score.ToString();
    }

    public void AddTitle(Title title)
    {
        GameObject c;
        if (title == Title.Omg)
        {
            c = Instantiate(_omg, transform);
        }
        else if (title == Title.Perfect)
        {
            c = Instantiate(_perfect, transform); 
        }
        else if (title == Title.Wow)
        {
            c = Instantiate(_wow, transform);
        }
        else
        {
            return;
        }
        var rec = c.GetComponent<RectTransform>();
        var pos = rec.position;
        pos.x += Random.Range(-600, 100);
        rec.position = pos;
        Destroy(c, 2f);
    }

    private void CreateRandomCount(int i)
    {
        var c = Instantiate(_countPr, transform);
        var rec = c.GetComponent<RectTransform>();
        var pos = rec.position;
        pos.x += Random.Range(-200, 200);
        pos.y += Random.Range(-100, 100);
        rec.position = pos;
        c.SetScore(i);
    }

    public void CreateVerticalCount(int i, Vector3 pos1)
    {
        var c = Instantiate(_countPr, transform);
        var rec = c.GetComponent<RectTransform>();
        var pos = rec.position;
        pos += pos1;
        // pos.y +=
        rec.position = pos;
        c.SetScore(i);
    }
}
