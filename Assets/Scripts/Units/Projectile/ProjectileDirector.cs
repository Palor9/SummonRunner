using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileDirector : MonoBehaviour
{
    private Rigidbody2D projectileRB;

    internal static PlayerMovement playerMovement;

    private Vector2 hitPosition;

    internal static Projectile projectile;

    public static void RegisterPlayer(PlayerMovement playerBody)
    {
        playerMovement = playerBody;
    }

    public void Awake()
    {
        projectile = GetComponent<Projectile>();
        projectileRB = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        hitPosition = playerMovement.GetComponent<Rigidbody2D>().position;
    }

    public void FixedUpdate()
    {
        projectileRB.position = Vector2.MoveTowards(this.projectileRB.position, this.hitPosition, projectile.Speed * Time.deltaTime);

        if (this.projectileRB.position == this.hitPosition)
        {
            Debug.Log("Booom!");
            Destroy(projectileRB.GameObject());
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerMovement.GetComponent<Collider2D>())
        {
            playerMovement.Health -= projectile.DMG;
            Debug.Log(playerMovement.Health.ToString());
        }
    }
}