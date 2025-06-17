using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource ShootingChannel;

    public AudioClip M4Shot;
    public AudioClip M1911Shot;

    public AudioSource ReloadingSoundM4;
    public AudioSource ReloadingSoundM1911;

    public AudioSource EmptyMagazineSoundM1911;

    public AudioSource throwablesChannel;
    public AudioClip grenadeSound;

    public AudioClip zombieWalking;
    public AudioClip zombieChase;
    public AudioClip zombieAttack;
    public AudioClip zombieHurt;
    public AudioClip zombieDeath;

    public AudioSource zombieChannel;
    public AudioSource zombieChannel2;

    public AudioSource playerChannel;
    public AudioClip playerHurt;
    public AudioClip playerDie;

    public AudioClip gameOverMusic;

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol1911:
                ShootingChannel.PlayOneShot(M1911Shot);
                break;
            case WeaponModel.M4:
                ShootingChannel.PlayOneShot(M4Shot);
                break;
        }
    }

    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon) 
        {
            case WeaponModel.Pistol1911:
                ReloadingSoundM1911.Play();
                break;
            case WeaponModel.M4:
                ReloadingSoundM4.Play();
                break;
        }
    }

    
}
