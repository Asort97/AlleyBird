using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{

    private int _currentPoints;
    private int _bestPoints;
    [SerializeField] private Text _bestScore;
    [SerializeField] private Text _currentScore;

    [SerializeField] private Text _endScore;
    private void Start()
    {
        _bestPoints = PlayerPrefs.GetInt("BEST_SCORE");
        _bestScore.text = "BEST " + _bestPoints.ToString();
    }

    public void InEndScore()
    {
        _endScore.text = _currentScore.text;
    }
    public void AddPoint()
    {
        _currentPoints++;
        _currentScore.text = _currentPoints.ToString();
        if(_currentPoints > _bestPoints)
        {
            PlayerPrefs.SetInt("BEST_SCORE", _currentPoints);
            _bestScore.text = "BEST " + _currentPoints;
        }
    }
}
