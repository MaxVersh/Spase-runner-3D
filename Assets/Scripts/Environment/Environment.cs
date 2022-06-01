using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private GameObject _player;
    public GameObject front;
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public float offset = 375f;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        front.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y,
            _player.transform.position.z + offset);
        if (_player.transform.position.z > part2.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
        }
    }
}
