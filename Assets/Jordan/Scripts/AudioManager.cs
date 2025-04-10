using JetBrains.Annotations;
using UnityEngine;


[System.Serializable]
public class Sound
{
    AudioSource source;
    public string nameClip;
    public AudioClip clip;

    [Range (0f, 1f)]
    public float volume;
    [Range (0f, 3f)]
    public float pitch;

    public bool loop = false;
    public bool isPlaying = false;

    public void setSource(AudioSource sourceClip)
    {
        this.source = sourceClip;
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.playOnAwake = isPlaying;
        source.loop = loop;
    }

    public void SetVolume(float vol)
    {
        if (source != null)
        {
            source.volume = vol;
        }
    }

    public void Stop()
    {
        source.Stop();
    }

    public void Play()
    {
        source.Play();
    }
}
public class AudioManager : MonoBehaviour
{
   public static AudioManager Instance;


    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }  
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject play = new GameObject("Sound : " + i + " : " + sounds[i].nameClip);
            play.transform.SetParent(this.transform);
            sounds[i].setSource(play.AddComponent<AudioSource>());
        } 
    }

    public void PlaySound(string name)
    {
        for (int i = 0; i< sounds.Length; i++)
        {
            if (sounds[i].nameClip == name)
            {
                sounds[i].Play();
                return;
            }
        }
    }

    public void StopMusic(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].nameClip == name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

    public void VolumeAmount(float vol)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].loop == false)
            {
                //  sounds[i].Play();
                sounds[i].SetVolume(vol);
              //  sounds.so
            }
        }
    }
    public void MusicAmount(float vol)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].loop == true)
            {
                //  sounds[i].Play();
                sounds[i].SetVolume(vol);
                //  sounds.so
            }
        }
    }
    // Update is called once per frame
   
}
