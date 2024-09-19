using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.Device;
using System.Threading;

public class DamageDeal : EnemyDirector
{
    internal EnemyStats EnemyStats;

    private bool isDamaging;
    private double timer;

    Mutex mutexObj = new();

    private void Awake()
    {
        EnemyStats = GetComponent<EnemyStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.Equals(PlayerBatch.PlayerMovement.Collider))
        {            
            isDamaging = true;
            StartCoroutine(DPS());
            timer = this.EnemyStats.DamageSpeed;           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isDamaging = false;
        StopCoroutine(DPS());
    }

    IEnumerator DPS()
    {
        while (isDamaging)
        {
            if (this.timer <= 0)
            {
                PlayerBatch.PlayerMovement.Health -= EnemyStats.DMG;
                Debug.Log(PlayerBatch.PlayerMovement.Health.ToString());
                
            }
            yield return new WaitForSeconds(this.EnemyStats.DamageSpeed);
        }
        Debug.Log("I am already died");
    }


    public new void FixedUpdate()
    {
        base.FixedUpdate();
        this.timer -= Time.deltaTime;
    }

    public void Update()
    {
        HealthBar.UpdateImage(PlayerBatch.PlayerMovement.Health);
    }
}

