using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; } // Static object of the class.
    public SoundManager SOMA;

    private void Awake() // Ensure there is only one instance.
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Will persist between scenes.
            Initialize();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances.
        }
    }

    private void Initialize()
    {
        SOMA = new SoundManager();
        SOMA.Initialize(gameObject);
        SOMA.AddSound("Engines", Resources.Load<AudioClip>("Engines"), SoundManager.SoundType.SOUND_SFX);
        SOMA.AddSound("Explode", Resources.Load<AudioClip>("Explode"), SoundManager.SoundType.SOUND_SFX);
        SOMA.AddSound("Fire", Resources.Load<AudioClip>("Fire"), SoundManager.SoundType.SOUND_SFX);
        SOMA.AddSound("Teleport", Resources.Load<AudioClip>("Teleport"), SoundManager.SoundType.SOUND_SFX);

        SOMA.AddSound("Title", Resources.Load<AudioClip>("Title"), SoundManager.SoundType.SOUND_MUSIC);
        SOMA.AddSound("Wings", Resources.Load<AudioClip>("Wings"), SoundManager.SoundType.SOUND_MUSIC);

        SOMA.PlayMusic("Title");
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
        SOMA.PlayMusic("Wings");
    }
}
