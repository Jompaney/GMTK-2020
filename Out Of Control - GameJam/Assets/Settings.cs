using UnityEngine.Audio;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
