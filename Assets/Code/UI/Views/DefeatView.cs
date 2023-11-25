using System;
using ScreenManager.Runtime.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Views
{
    public class DefeatView : BaseView
    {
        [SerializeField] private TMP_Text _defeatText;
        [SerializeField] private Button _buttonRestart;

        public event Action RestartClick;
        
        private void Awake()
        {
            _buttonRestart.onClick.AddListener(() => RestartClick?.Invoke());
        }

        public void SetDefeatText(string text)
        {
            _defeatText.SetText(text);
        }
    }
}