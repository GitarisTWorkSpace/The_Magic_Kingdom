using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup soundMixer;
    [SerializeField] private AudioMixerGroup musicMixer;

    [SerializeField] private Toggle soundMuteToggle;
    [SerializeField] private Toggle musicMuteToggle;

    [SerializeField] private bool soundMute;
    [SerializeField] private bool musicMute;

    [SerializeField] private Slider soundVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    [SerializeField] private float soundVolume;
    [SerializeField] private float musicVolume;

    public void SoundMute(bool status)
    {
        if (status)
            soundMixer.audioMixer.SetFloat("SoundVolume", -80f);
        else
            soundMixer.audioMixer.SetFloat("SoundVolume", 0f);
        soundMute = status;
        SaveSoundSettings();        
    }

    public void MusicMute(bool status) 
    {
        if (status)
            musicMixer.audioMixer.SetFloat("MusiñVolume", -80f);
        else
            musicMixer.audioMixer.SetFloat("MusiñVolume", 0f);
        musicMute = status;
        SaveMusicSettings();        
    }

    public void SoundVolume(float volume)
    {
        soundVolume = Mathf.Lerp(-80f, 0f, volume);
        if (!soundMute)
            soundMixer.audioMixer.SetFloat("SoundVolume", soundVolume);
        SaveSoundSettings();
    }

    public void MusicVolume(float volume)
    {
        musicVolume = Mathf.Lerp(-80f, 0f, volume);
        if (!musicMute)
            musicMixer.audioMixer.SetFloat("MusiñVolume", musicVolume);
        SaveMusicSettings();
    }

    private void Start()
    {
        LoadMusicSettings();
        LoadSoundSettings();
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetInt("SoundMute", System.Convert.ToInt32(soundMute));
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }

    private void SaveMusicSettings()
    {        
        PlayerPrefs.SetInt("MusicMute", System.Convert.ToInt32(musicMute));
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }    

    private void LoadSoundSettings()
    {
        if (PlayerPrefs.HasKey("SoundMute"))
        {
            soundMute = System.Convert.ToBoolean(PlayerPrefs.GetInt("SoundMute"));
            SoundMute(soundMute);
            soundMuteToggle.isOn = soundMute;
        }
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            soundVolume = PlayerPrefs.GetFloat("SoundVolume");
            soundVolumeSlider.value = Mathf.Lerp(1f, 0f, soundVolume);
            SoundVolume(Mathf.Lerp(1f, 0f, soundVolume));
        }
    }

    private void LoadMusicSettings()
    {        
        if (PlayerPrefs.HasKey("MusicMute"))
        {
            musicMute = System.Convert.ToBoolean(PlayerPrefs.GetInt("MusicMute"));
            MusicMute(musicMute);
            musicMuteToggle.isOn = musicMute;            
        }
        
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");            
            musicVolumeSlider.value = Mathf.Lerp(1f, 0f, musicVolume);
            MusicVolume(Mathf.Lerp(1f, 0f, musicVolume));
        }
    }
}
