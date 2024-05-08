using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoObjeto : MonoBehaviour
{
    public string[] TagsDestino = { "Mesa" };
    public GameObject LocalEspecifico;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in TagsDestino)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                GameObject objeto = transform.gameObject;
                objeto.transform.position = LocalEspecifico.transform.position;
                objeto.transform.rotation = LocalEspecifico.transform.rotation;
                objeto.transform.parent = LocalEspecifico.transform;
                break;
            }
        }
    }
}