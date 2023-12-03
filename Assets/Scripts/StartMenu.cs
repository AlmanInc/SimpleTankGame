using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

namespace TankGameCore
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(() => SceneManager.LoadSceneAsync("Main"));
        }
    }
}