using UnityEngine;

namespace GameManager
{
    public class Logo : MonoBehaviour
    {
        public GameObject levelChanger;
        
        // Start is called before the first frame update
        private void Awake()
        {            
            if (PlayerPrefs.GetString("PreviousScene") != "DataLoad")
            {
                levelChanger.SetActive(false);
            }
        }

        private void Start()
        {
            if (AudioManager.onInstance.IsPlay("Sad"))
                AudioManager.onInstance.Stop("Sad");
            
            if (!AudioManager.onInstance.IsPlay("Main"))
                AudioManager.onInstance.Play("Main");
        }
    }
}
