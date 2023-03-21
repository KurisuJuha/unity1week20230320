using AnnulusGames.LucidTools.Inspector;
using JuhaKurisu.PopoTools.Utility;
using UnityEngine;

[HideMonoScript]
public class GameManager : Singleton<GameManager>
{
    [SerializeField, Required] private Player _player;
    public Player player => _player;
}
