using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{
    public class Bedroom : MonoBehaviour
    {
        private bool bedFlag, mirrorFlag, firstChange;
        public Sprite[] bedSpriteArr, mirrorSpriteArr;
        public Image bedBtn, mirrorBtn;

        private int nowIndex;

        public LevelChanger levelChanger;

        private void Start()
        {
            InvokeRepeating(nameof(ButtonChanger), 0f, 1.0f);
        }

        // Update is called once per frame
        private void ButtonChanger()
        {
            if (firstChange)
            {
                firstChange = false;
                levelChanger.FadeToLevel("Bedroom_real");
            }
            else
            {
                if (!bedFlag)
                    bedBtn.sprite = bedSpriteArr[nowIndex];
                
                if (!mirrorFlag)
                    mirrorBtn.sprite = mirrorSpriteArr[nowIndex];

                nowIndex = nowIndex == 1 ? 0 : 1;    
            }
        }

        public void OnBtnClick(string btnName)
        {
            switch (btnName)
            {
                case "onBed":
                    bedFlag = true;
                    break;
                case "onMirror":
                    mirrorFlag = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (bedFlag && mirrorFlag)
                firstChange = true;
        }
    }
}
