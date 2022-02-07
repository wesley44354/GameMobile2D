using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] private string name;
    public string Name 
    { 
        get => name; 
        set => value = name; 
    }

    [SerializeField] private AudioClip clip;

    
    [SerializeField] [Range(0f, 1f)] private float volume = 0.7f;
    [SerializeField] [Range(0.5f, 1.5f)] private float pitch = 1f;


    [SerializeField] [Range(0f, 0.5f)] private float randomVolume = 0.1f;
    [SerializeField] [Range(0f, 0.5f)] private float randomPich = 0.1f;


    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPich / 2f, randomPich / 2f));
        source.Play();
    }
}


public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one AudioManager in the scene");
        }
        else
        {
            instance = this;
        }
    }

    [SerializeField]
    Sound[] sounds;

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject($"Sound_{i}_{sounds[i].Name}");
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }

        PlaySound("Music");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].Name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        // no sound with _name
        Debug.LogWarning("AudioManager: Sound not found in list: " + _name);
    }
}
