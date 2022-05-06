using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveCloud : MonoBehaviour
{
    public GameObject rain;
    public float delayBeforeRain = 1f;
    public Transform rainSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rainSpawnPoint = gameObject.transform.Find("Rain Spawn Point");
        Invoke("dropRain", delayBeforeRain);
        Invoke("disappear", delayBeforeRain * 2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void dropRain()
    {
        Instantiate(rain, rainSpawnPoint.position, rainSpawnPoint.rotation);
    }

    private void disappear()
    {
        Destroy(gameObject);
    }
}
