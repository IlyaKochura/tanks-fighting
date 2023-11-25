using Code.UI.Views;
using ScreenManager.Runtime.Contracts;
using UnityEngine.SceneManagement;

namespace Code.UI.Screens
{
    public class DefeatScreen : IUIScreen
    {
        private readonly DefeatView _view;

        public DefeatScreen(DefeatView view)
        {
            _view = view;

            _view.RestartClick += RestartGame;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void Show()
        {
            _view.SetDefeatText($"Defeat");
            
            _view.Show();
        }

        public void Hide()
        {
            _view.Hide();
        }
    }
}