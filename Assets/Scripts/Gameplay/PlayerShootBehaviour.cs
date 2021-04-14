using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    [SerializeField]
    private BulletEmitterBehaviour _bulletEmitter;
    [SerializeField]
    private float _shotSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _bulletEmitter)
            _bulletEmitter.Fire(transform.forward * _shotSpeed);
    }
}
