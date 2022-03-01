using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Parallax : MonoBehaviour
{
    private float _length, startPosition;

    public GameObject p_camera;

    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (p_camera.transform.position.x * (1 - parallaxEffect));
        float distance = (p_camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        if (temp > startPosition + _length) 
        {
            startPosition += _length;
        }else if (temp < startPosition - _length)
        {
            startPosition -= _length;
        }
    }
}
