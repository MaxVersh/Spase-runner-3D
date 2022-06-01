using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    public float bound;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position,_player.transform.position) > bound && transform.position.z<_player.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
