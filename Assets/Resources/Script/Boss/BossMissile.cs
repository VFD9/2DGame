using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : Object
{
    GameObject Player;

    public override void Initialize()
    {
        base.Name = "BossMissile";
        base.Hp = 0;
        base.Speed = 1.5f;
        base.ObjectAnim = GetComponent<Animator>();

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Progress()
    {
        if (transform.position.x <= Camera.main.transform.position.x + BackgroundManager.Instance.xScreenHalfSize)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(
                Camera.main.transform.position.x - BackgroundManager.Instance.xScreenHalfSize - 2.0f,
                Random.Range(Player.transform.position.y - 1.0f, Player.transform.position.y + 1.0f)), 0.02f);

            float angle = Mathf.Atan2(transform.position.y - Player.transform.position.y, transform.position.x - Player.transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        else
        {
            gameObject.SetActive(false);
            transform.GetComponent<BoxCollider2D>().enabled = false;
            transform.SetParent(EnemyManager.Instance.transform.GetChild(1));
        }
    }

    public override void Release()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            transform.GetComponent<BoxCollider2D>().enabled = false;
            transform.SetParent(EnemyManager.Instance.transform);
        }
    }
}
