using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SignSine.UserInterface
{
    public class ScoreLeaderBoard : MonoBehaviour
    {
        public int score;

        [SerializeField] private Text _scoreText;
        [SerializeField] private string _nickname;

        public void UpdateScore(int newScore)
        {
            score = newScore;
            _scoreText.text = score.ToString() + " - " + _nickname;
        }
    }
}