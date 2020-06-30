using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _authors;
    [SerializeField] private Button _exit;
    [SerializeField] private AuthorsPanel _authorsPanel;

    private void OnEnable()
    {
        _play.onClick.AddListener(OnPlayButtonClick);
        _authors.onClick.AddListener(OnAuthorsButtonClick);
        _exit.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _play.onClick.RemoveListener(OnPlayButtonClick);
        _authors.onClick.RemoveListener(OnAuthorsButtonClick);
        _exit.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void OnAuthorsButtonClick()
    {
        _authorsPanel.gameObject.SetActive(true);
        _authorsPanel.Open();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}

