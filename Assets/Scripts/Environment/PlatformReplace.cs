using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReplace : MonoBehaviour
{
    private GameObject _player;
    public float distance;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    
    void Update()
    {
        distance = Vector3.Distance(_player.transform.position, transform.position);
        if (distance > 0 && _player.transform.position.z > transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 150);
        }
    }
}
