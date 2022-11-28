using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource AudioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        AudioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);
    }
}
