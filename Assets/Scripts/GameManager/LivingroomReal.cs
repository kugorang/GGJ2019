using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{
    public class LivingroomReal : MonoBehaviour
    {
        public Sprite[] sofaSpriteArr, clockSpriteArr;
        public Image sofaBtn, clockBtn;

        private int _nowIndex;

        public LevelChanger levelChanger;

        private void Start()
        {
            PlayerPrefs.SetString("PreviousScene", "LivingroomReal");
            
            InvokeRepeating(nameof(ButtonChanger), 0f, 1.0f);
        }

        // Update is called once per frame
        private void ButtonChanger()
        {
            sofaBtn.sprite = sofaSpriteArr[_nowIndex];
            clockBtn.sprite = clockSpriteArr[_nowIndex];

            _nowIndex = _nowIndex == 1 ? 0 : 1;
        }
    }
}
