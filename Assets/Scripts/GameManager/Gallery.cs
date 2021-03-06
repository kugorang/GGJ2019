﻿using UnityEngine;

namespace GameManager
{
    public class Gallery : MonoBehaviour
    {
        private void Awake()
        {
            PlayerPrefs.SetString("PreviousScene", "Gallery");
        }

        // Start is called before the first frame update
        private void Start()
        {
            if (AudioManager.onInstance.IsPlay("Sad"))
                AudioManager.onInstance.Stop("Sad");
            
            if (!AudioManager.onInstance.IsPlay("Main"))
                AudioManager.onInstance.Play("Main");
        }
    }
}
