using UnityEngine;
using AnnulusGames.LucidTools.Inspector;
using AnnulusGames.LucidTools.RandomKit;
using AnnulusGames.LucidTools.Audio;

public class PlayerSoundSource : MonoBehaviour
{
    [SerializeField] private double interval;
    [SerializeField] private AudioClip[] sePathes;
    [SerializeField, Required] private Rigidbody2D rb2d;
    [SerializeField, Range(0, 1)] private float volume;
    [SerializeField, ReadOnly] private double elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime * rb2d.velocity.magnitude;
        if (elapsedTime > interval)
        {
            LucidAudio.PlaySE(sePathes.RandomElement())
                .SetVolume(volume);
            elapsedTime = 0;
        }
    }
}
