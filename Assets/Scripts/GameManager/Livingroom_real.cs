using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{
    public class Livingroom_real : MonoBehaviour
    {
        private bool sofaFlag, clockFlag, firstChange;
        public Sprite[] sofaSpriteArr, clockSpriteArr;
        public Image sofaBtn, clockBtn;

        private int nowIndex;

        public LevelChanger levelChanger;

        private void Start()
        {
            if (AudioManager.onInstance.IsPlay("Main"))
            {
                AudioManager.onInstance.Stop("Main");
                AudioManager.onInstance.Play("Sad");                
            }
                        
            InvokeRepeating(nameof(ButtonChanger), 0f, 1.0f);
        }

        // Update is called once per frame
        private void ButtonChanger()
        {
            if (firstChange)
            {
                firstChange = false;
                levelChanger.FadeToLevel("Livingroom_real");
            }
            else
            {
                if (!sofaFlag)
                    sofaBtn.sprite = sofaSpriteArr[nowIndex];
                
                if (!clockFlag)
                    clockBtn.sprite = clockSpriteArr[nowIndex];

                nowIndex = nowIndex == 1 ? 0 : 1;    
            }
        }

        public void OnBtnClick(string btnName)
        {
            switch (btnName)
            {
                case "onSofa":
                    sofaFlag = true;
                    break;
                case "onClock":
                    clockFlag = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (sofaFlag && clockFlag)
                firstChange = true;
        }
    }
}
