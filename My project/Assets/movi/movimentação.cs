using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentação : MonoBehaviour
{

    public float velocity = 10.0f;
    public float rotation = 90.0f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(x, 0, y) * velocity;

        transform.Translate(dir * Time.deltaTime);
    }
}
