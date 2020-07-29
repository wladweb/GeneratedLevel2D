using UnityEngine;
using UnityEngine.UI;

public class AuthorsPanel : MonoBehaviour
{
    [SerializeField] private Button _close;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _close.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnDisable()
    {
        _close.onClick.RemoveListener(OnCloseButtonClick);
    }

    public void Open()
    {
        _animator.Play("AuthorsOpen");
    }

    private void OnCloseButtonClick()
    {
        _animator.Play("AuthorsClose");
    }

    public void DeactivatePanel()
    {
        gameObject.SetActive(false);
    }
}
