using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateNavMesh : MonoBehaviour
{
    NavMeshSurface nms;
    // Start is called before the first frame update
    void Start()
    {
        nms = gameObject.GetComponent<NavMeshSurface>();


        Invoke("AAAA", 3f);
    }
    void AAAA()
    {
        {
            nms.BuildNavMesh();
        }
    }
}
