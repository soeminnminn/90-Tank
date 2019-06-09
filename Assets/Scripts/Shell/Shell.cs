﻿
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Shell : MonoBehaviour
{

    [HideInInspector] public int shooter;
    public Tile emptyTile;
    public Transform TopLeft;
    public Transform TopRight;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.keepAnimatorControllerStateOnDisable = true;
    }

    private void Update()
    {
        if (transform.position.magnitude > 7f)
            ObjectPool.GetInstance().RecycleObj(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("Shell hit " + other.name);
        Tank targetTank = other.GetComponent<Tank>();
        // Deal this damage to the tank.
        if (targetTank != null)
        {
            if (targetTank.m_PlayerNumber != shooter)
            {
                targetTank.TakeDamage();
                // Explode the shell.
                StartCoroutine(Explode());
            }
            else
                return;
        }


        else if (other.name == "Tilemap")
        {
            Tilemap map = other.GetComponent<Tilemap>();
            if (map != null)
            {
                Grid grid = map.GetComponentInParent<Grid>();
                Vector3 cellSize = grid.cellSize;
                Vector3Int roundPosition = Vector3Int.FloorToInt(new Vector3(TopLeft.position.x / cellSize.x, TopLeft.position.y / cellSize.y, 0));
                TileBase tile = map.GetTile(roundPosition);

                if (tile.name == "brickwall")
                {
                    map.SetTile(roundPosition, emptyTile);
                }

                roundPosition = Vector3Int.FloorToInt(new Vector3(TopRight.position.x / cellSize.x, TopRight.position.y / cellSize.y, 0));
                tile = map.GetTile(roundPosition);

                if (tile.name == "brickwall")
                {
                    map.SetTile(roundPosition, emptyTile);
                }

                // Explode the shell.
                StartCoroutine(Explode());

            }
        }
        else if (other.name == "Shell")
        {
            Shell shell = other.GetComponent<Shell>();
            if (shell.shooter != shooter)
            {
                StartCoroutine(Explode());
            }
        }
        else
        {
            StartCoroutine(Explode());
        }

    }


    private IEnumerator Explode()
    {
        animator.SetTrigger("explode");
        GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(0.3f);
        ObjectPool.GetInstance().RecycleObj(gameObject);
    }
}
