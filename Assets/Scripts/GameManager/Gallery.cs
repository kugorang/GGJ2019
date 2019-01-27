using UnityEngine;

namespace GameManager
{
    public class Gallery : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            if (!AudioManager.onInstance.IsPlay("Sad")) 
                return;
            
            AudioManager.onInstance.Stop("Sad");
            AudioManager.onInstance.Play("Main");
        }
    }
}
