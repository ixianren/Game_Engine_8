using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartsOption : MonoBehaviour
{
    public GameObject audio;
    Transform _transform;
    int flag=0;
    bool _ismoving=false;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    public void _SlideRight()
    {
        if (!_ismoving)
        {
            _ismoving = true;
            StartCoroutine(SlideRight(0.05f));
        }
    }
    public void _SlideLeft()
    {
        if (!_ismoving)
        {
            _ismoving = true;
            StartCoroutine(SlideLeft(0.05f));
        }
    }
    IEnumerator SlideRight(float pause)
    {
        audio.SetActive(false);
        float distance=0;
        Vector3 _originposition = _transform.position;

        if (flag < 3)
        {
            while (distance<=10)
            {
                distance+= pause;
                _transform.position = new Vector3(_originposition.x - distance, _originposition.y, _originposition.z);
                yield return new WaitForSeconds(0.01f);
            }
            flag++;
        }
        else yield return null;
        audio.SetActive(true);
        _ismoving = false;
    }
    IEnumerator SlideLeft(float pause)
    {
        audio.SetActive(false);
        float distance = 0;
        Vector3 _originposition = _transform.position;

        if (flag > -3)
        {
            while (distance <= 10)
            {
                distance += pause;
                _transform.position = new Vector3(_originposition.x + distance, _originposition.y, _originposition.z);
                yield return new WaitForSeconds(0.01f);
            }
            flag--;
        }
        else yield return null;
        audio.SetActive(true);
        _ismoving = false;
    }
    // Update is called once per frame

}
