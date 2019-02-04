using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{
    public class Bedroom : MonoBehaviour
    {
        private bool _bedFlag, _mirrorFlag, _firstChange;
        public Sprite[] bedSpriteArr, mirrorSpriteArr;
        public Image bedBtn, mirrorBtn;

        private int _nowIndex;

        public LevelChanger levelChanger;

        private void Start()
        {
            PlayerPrefs.SetString("PreviousScene", "Bedroom");
            
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
                
                levelChanger.FadeToLevel("BedroomReal");
            }
            else
            {
                if (!_bedFlag)
                    bedBtn.sprite = bedSpriteArr[_nowIndex];
                
                if (!_mirrorFlag)
                    mirrorBtn.sprite = mirrorSpriteArr[_nowIndex];

                _nowIndex = _nowIndex == 1 ? 0 : 1;    
            }
        }

        public void OnBtnClick(string btnName)
        {
            switch (btnName)
            {
                case "onBed":
                    _bedFlag = true;
                    break;
                case "onMirror":
                    _mirrorFlag = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_bedFlag && _mirrorFlag)
                _firstChange = true;
        }
    }
}
