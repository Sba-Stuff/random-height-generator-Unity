using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class randomheight : MonoBehaviour
{
    public float maxScale = 10f;
    public float speed = 1f;
    public bool updateOn = true;
    private Vector3 v3OrgPos;
    private float orgScale;
    private float endScale;
    public int minimum_time_range = 1;
    public int maximum_time_range = 9;
    // Use this for initialization
    void Start () {
        v3OrgPos = transform.position;
       orgScale = transform.localScale.z;
        //endScale = orgScale;
        StartCoroutine(updateOff());
    }
   // void Awake()
   // {
   //     v3OrgPos = transform.position - transform.forward;
   //     orgScale = transform.localScale.z;
   //     endScale = orgScale;
   // }

    // Update is called once per frame
    void Update()
    {
        if(updateOn==true)
        { ResizeOn(); }
       // 
    }
    private void ResizeOn()
    {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.MoveTowards(transform.localScale.z, endScale, Time.deltaTime * speed));
            transform.position = v3OrgPos + (transform.forward) * (transform.localScale.z / 2.0f + orgScale / 2.0f);
            //if (Input.GetKeyDown(KeyCode.S))
            //{
            endScale = maxScale;
            // }
            // else if (Input.GetKeyDown(KeyCode.R))
            // {
            //   endScale = orgScale;
            // }
    }
    IEnumerator updateOff()
    {
        yield return new WaitForSeconds(Random.Range(minimum_time_range,maximum_time_range));
        updateOn = false;
    }
}