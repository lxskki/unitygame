using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarObjetos : MonoBehaviour
{
    public string[] Tags;
    public GameObject ObjSegurando;
    [Space(20)]
    public float DistanciaMax;
    public bool Segurando;
    public GameObject LocalPegar;
    public LayerMask Layoso;

    // Update is called once per frame
    void Update()
    {
        if (Segurando)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DroparObjeto();
                return;
            }
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, DistanciaMax, Layoso, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);
                for (int x = 0; x < Tags.Length; x++)
                {
                    if (hit.transform.gameObject.CompareTag(Tags[x]))
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            SegurarObjeto(hit.transform.gameObject);
                            return;
                        }
                    }
                }
            }
        }
    }

    void SegurarObjeto(GameObject objeto)
    {
        Segurando = true;
        ObjSegurando = objeto;
        if (ObjSegurando.GetComponent<Rigidbody>())
        {
            ObjSegurando.GetComponent<Rigidbody>().isKinematic = true;
        }
        ObjSegurando.transform.position = LocalPegar.transform.position;
        ObjSegurando.transform.rotation = LocalPegar.transform.rotation;
        ObjSegurando.transform.parent = LocalPegar.transform;
    }

    void DroparObjeto()
    {
        Segurando = false;
        ObjSegurando.transform.parent = null;
        if (ObjSegurando.GetComponent<Rigidbody>())
        {
            ObjSegurando.GetComponent<Rigidbody>().isKinematic = false;
        }
        ObjSegurando = null;
    }
}
