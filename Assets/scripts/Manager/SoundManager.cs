using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoSingleton<SoundManager>
{
    public AudioClip pung;
    public AudioClip turret;
    public AudioClip coin;
    public AudioSource pungSource;
    public AudioSource turretSource;
    public AudioSource coinSource;

    public override void Awake()
    {
        base.Awake();
        pungSource = gameObject.AddComponent<AudioSource>();
        pungSource.clip = pung;
        pungSource.loop = false;
        pungSource.playOnAwake = false;
        turretSource = gameObject.AddComponent<AudioSource>();
        turretSource.clip = turret;
        turretSource.loop = false;
        turretSource.playOnAwake = false;
        coinSource = gameObject.AddComponent<AudioSource>();
        coinSource.clip = coin;
        coinSource.loop = false;
        coinSource.playOnAwake = false;
    }
}
