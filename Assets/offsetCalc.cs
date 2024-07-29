using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offsetCalc : MonoBehaviour
{
    //As Transform Changes, Change the Offset
    public float offset;
    private Vector3 center = new Vector3(0f,-1f,0f);


    private Transform trf;

    private BoxCollider2D bcd;
    private Vector3 newPosCollider;
    //private Vector2 size = bcd.size;
    //private Vector3 centerPoint = new Vector3(bcd.center.x, bcd.center.y, 0f);
   //private Vector3 colWorldPos = transform.TransformPoint(bcd.center);


    // Start is called before the first frame update
    void Start()
    {
        newPosCollider = transform.position;
        bcd = GetComponent<BoxCollider2D>();
        offset = center.y - transform.position.y;
        newPosCollider.y = newPosCollider.y + 2* offset;
        Vector3 inversePos = transform.InverseTransformPoint(newPosCollider);
        bcd.offset= new Vector2(inversePos.x, inversePos.y);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
