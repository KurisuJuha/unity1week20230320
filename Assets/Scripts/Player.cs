using AnnulusGames.LucidTools.Inspector;
using UnityEngine;

[HideMonoScript]
public class Player : MonoBehaviour
{
    [SerializeField, Required] private PlayerController _playerController;
    public PlayerController playerController => _playerController;

    [SerializeField, Required] private PlayerAnimator _playerAnimator;
    public PlayerAnimator playerAnimator => _playerAnimator;

    [SerializeField, Required] private PlayerSoundSource _playerSound;
    public PlayerSoundSource playerSound => _playerSound;
}
