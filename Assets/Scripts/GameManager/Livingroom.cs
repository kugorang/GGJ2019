using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{
    public class Livingroom : MonoBehaviour
    {
        private bool _sofaFlag, _clockFlag, _firstChange;
        public Sprite[] sofaSpriteArr, clockSpriteArr;
        public Image sofaBtn, clockBtn;

        private int _nowIndex;

        public LevelChanger levelChanger;

        private void Start()
        {
            PlayerPrefs.SetString("PreviousScene", "Livingroom");
            
            InvokeRepeating(nameof(ButtonChanger), 0f, 1.0f);
        }

        // Update is called once per frame
        private void ButtonChanger()
        {
            if (_firstChange)
            {
                _firstChange = false;
                
                AudioManager.onInstance.Stop("Main");
                AudioManager.onInstance.Play("Sad");
                
                levelChanger.FadeToLevel("LivingroomReal");
            }
            else
            {
                if (!_sofaFlag)
                    sofaBtn.sprite = sofaSpriteArr[_nowIndex];
                
                if (!_clockFlag)
                    clockBtn.sprite = clockSpriteArr[_nowIndex];

                _nowIndex = _nowIndex == 1 ? 0 : 1;    
            }
        }

        public void OnBtnClick(string btnName)
        {
            switch (btnName)
            {
                case "onSofa":
                    _sofaFlag = true;
                    break;
                case "onClock":
                    _clockFlag = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_sofaFlag && _clockFlag)
                _firstChange = true;
        }
    }
}
