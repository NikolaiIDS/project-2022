using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public GameObject CamCollider;

    private Vector3 defaultCamPosition;
    private Vector3 currCamPos;
    
    bool _camFix = true;
    bool _canLerp = false;

    // Start is called before the first frame update
    void Start()
    {
        defaultCamPosition = new Vector3(CamCollider.transform.localPosition.x, CamCollider.transform.localPosition.y, CamCollider.transform.localPosition.z);
        StartCoroutine(CamFixRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        currCamPos = CamCollider.transform.localPosition;     
    }
    IEnumerator CamFixRoutine()
    {
        while (_camFix == true)
        {
            yield return new WaitForSeconds(3f);
            CamCollider.transform.localPosition = defaultCamPosition;
            _canLerp = true;
                      
        }
    }
}
