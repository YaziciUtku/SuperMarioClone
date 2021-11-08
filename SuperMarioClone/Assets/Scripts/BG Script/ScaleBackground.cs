using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    SpriteRenderer sR;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(1, 1, 1);

        float widht = sR.sprite.bounds.size.x;
        float height = sR.sprite.bounds.size.y;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight / Screen.height * Screen.width;

        Vector3 tempScale = transform.localScale;
        tempScale.x = worldWidth / widht + 0.1f;
        tempScale.y = worldHeight / height + 0.1f;

        transform.localScale = tempScale;
    }





















}// CLASS
