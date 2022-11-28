using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initiator : MonoBehaviour
{
    private Spawner _spawn;

    private void Start()
    {
        _spawn = GetComponent<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(waiteForSeconds());
        }
    }

    IEnumerator waiteForSeconds()
    {
        _spawn.onetimecall = true;
        _spawn.waveCountdown = _spawn.wait1;
        yield return waiteForSeconds();
    }
}
