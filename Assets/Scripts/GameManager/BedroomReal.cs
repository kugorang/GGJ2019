using UnityEngine;
using UnityEngine.UI;

namespace GameManager
{
    public class BedroomReal : MonoBehaviour
    {
        public Sprite[] bedSpriteArr, mirrorSpriteArr;
        public Image bedBtn, mirrorBtn;

        private int _nowIndex;

        public LevelChanger levelChanger;

        private void Start()
        {
            PlayerPrefs.SetString("PreviousScene", "BedroomReal");
            
            InvokeRepeating(nameof(ButtonChanger), 0f, 1.0f);
        }

        // Update is called once per frame
        private void ButtonChanger()
        {
            bedBtn.sprite = bedSpriteArr[_nowIndex];
            mirrorBtn.sprite = mirrorSpriteArr[_nowIndex];

            _nowIndex = _nowIndex == 1 ? 0 : 1;
        }
    }
}
