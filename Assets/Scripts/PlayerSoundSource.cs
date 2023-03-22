using UnityEngine;
using UniRx;
using KanKikuchi.AudioManager;
using AnnulusGames.LucidTools.Inspector;
using AnnulusGames.LucidTools.RandomKit;

public class PlayerSoundSource : MonoBehaviour
{
    [SerializeField] private double interval;
    [SerializeField, Required] private Rigidbody2D rb2d;
    [SerializeField, ReadOnly] private double elapsedTime;
    [SerializeField, ReadOnly]
    private string[] sePathes = new string[]{
        SEPath.DART0,
        SEPath.DART1,
        SEPath.DART2,
        SEPath.DART3,
        SEPath.DART4
    };

    [SerializeField, Range(0, 1)] private float volume;

    private void Update()
    {
        elapsedTime += Time.deltaTime * rb2d.velocity.magnitude;
        if (elapsedTime > interval)
        {
            SEManager.Instance.Play(sePathes.RandomElement(), volumeRate: volume);
            elapsedTime = 0;
        }
    }
}
