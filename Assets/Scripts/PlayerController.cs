using UnityEngine;
using AnnulusGames.LucidTools.Inspector;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField, Required] private Rigidbody2D rb2d;

    private void Update()
    {
        rb2d.velocity = Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), 1) * walkSpeed;
    }
}
