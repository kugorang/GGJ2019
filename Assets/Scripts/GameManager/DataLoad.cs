using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class DataLoad : MonoBehaviour
    {
        private bool nextSceneLoad;
        
        // Update is called once per frame
        private void Update()
        {
            if (nextSceneLoad || !AudioManager.onInstance.loadingEnd || !AndroidBackBtnManager.onInstance.loadingEnd) 
                return;
            
            nextSceneLoad = true;
            SceneManager.LoadScene("Logo");
        }
    }
}
