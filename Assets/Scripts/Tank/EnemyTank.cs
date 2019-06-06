﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyTank : Tank
{
    private float directionChangeInteval;
    private float directionChangeTimer;

    private int[] healthArray = { 1, 2, 2, 3 };
    private float[] speedArray = { 0.5f, 0.5f, 1f, 0.5f };
    private int[] scoreArray = { 100, 200, 300, 400 };

    public int Type
    {
        set
        {
            health = healthArray[value - 1];
            speed = speedArray[value - 1];
            score = scoreArray[value - 1];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerNumber = -1;
        moveDirection = Vector2.down;
        m_ChargeTime = 2f;
        directionChangeTimer = 0;
        directionChangeInteval = Random.Range(3,5);
    }

    public IEnumerator Born(int type, int position)
    {
        Type = type;
        animator.SetInteger("type", type);
        animator.SetInteger("health", health);

        Vector2[] enemySpawnPoint = { new Vector2(-3f, 3f), new Vector2(0f, 3f), new Vector2(3f, 3f) };
        transform.position = enemySpawnPoint[position-1];
        float speed0 = speed;
        speed = 0;
        isInvincible = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
        speed = speed0;
    }


    // Update is called once per frame
    void Update()
    {
        m_CurrentChargeTime += Time.deltaTime;
        if (m_CurrentChargeTime >= m_ChargeTime)
        {
            Fire();
            m_CurrentChargeTime = 0f;
        }
        rigidbody2d.position += moveDirection * speed * Time.deltaTime;
        directionChangeTimer += Time.deltaTime;
        if (directionChangeTimer > directionChangeInteval)
        {
            SelectDirection();
            directionChangeInteval = Random.Range(1,5);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "WorldLimiter")
        {
            Debug.Log("tank hit ex bound");
            SelectDirection();
        }
    }

    private void SelectDirection()
    {
        Vector2 direction = moveDirection;
        if (transform.position.x < 0)
        {
            Vector2[] directChoice = { Vector2.up, Vector2.right, Vector2.right, Vector2.down, Vector2.down, Vector2.down, Vector2.left };
            moveDirection = directChoice[Random.Range(0,6)];
        }
        else
        {
            Vector2[] directChoice = { Vector2.up, Vector2.left, Vector2.left, Vector2.down, Vector2.down, Vector2.down, Vector2.right };
            moveDirection = directChoice[Random.Range(0,6)];
        }
        if (moveDirection == Vector2.up)
            rigidbody2d.rotation = 0f;
        else if (moveDirection == Vector2.down)
            rigidbody2d.rotation = 180f;
        else if (moveDirection == Vector2.left)
            rigidbody2d.rotation = 90f;
        else if (moveDirection == Vector2.right)
            rigidbody2d.rotation = -90f;

        Vector2 position = rigidbody2d.position;
        position.x = Mathf.RoundToInt(position.x / smallestGrid) * smallestGrid;
        position.y = Mathf.RoundToInt(position.y / smallestGrid) * smallestGrid;
        rigidbody2d.position = position;

        directionChangeTimer = 0;

    }

    float Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

}
