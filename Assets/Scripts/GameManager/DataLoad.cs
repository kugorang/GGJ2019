using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class DataLoad : MonoBehaviour
    {
        private bool _nextSceneLoad;
        
        // Update is called once per frame
        private void Update()
        {
            if (_nextSceneLoad || !AudioManager.onInstance.loadingEnd || !AndroidBackBtnManager.onInstance.loadingEnd) 
                return;
            
            _nextSceneLoad = true;
            PlayerPrefs.SetString("PreviousScene", "DataLoad");
            
            SceneManager.LoadScene("Logo");
        }
    }
}
