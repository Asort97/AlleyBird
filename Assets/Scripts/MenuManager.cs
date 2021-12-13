using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private BirdController _birdController;
    [SerializeField] private GameObject _startUI;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private Text _bestScore;


    [SerializeField] private GameObject _diePanel;
    [SerializeField] private Transform _scoreEnd;
    [SerializeField] private Transform _restartBtn;
    // Start is called before the first frame update
    private void Start()
    {
        int _bestPoints = PlayerPrefs.GetInt("BEST_SCORE");
        _bestScore.text = "BEST " + _bestPoints.ToString();
    }

    public void OnStartGame()
    {
        _startUI.SetActive(false);
        _gameUI.SetActive(true);        
        _birdController.isStart = true;
    }

    public void DieBird()
    {
        _diePanel.SetActive(true);
        _scoreManager.InEndScore();
        _scoreEnd.DOMoveX(0, 0.8f);
        _restartBtn.DOMoveX(0, 0.6f);
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(0);
    }
}
