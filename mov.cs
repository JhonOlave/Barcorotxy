using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform barco;
    public float velo = 1f;
    public float rotacionS = 1f;
    Vector3 targetX, targetY;
    Vector3 f;
    Vector3 towardsTarget;
    // float r=5f;
    void calcular()
    {
        //targetP=transform.position + Random.insideUnitSphere;
        // targetP= transform.Translate(Input.GetAxis("Horizontal"),0,Input.GetAxis("vertical"));
        targetX = Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * velo;
        targetY = Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * velo;
        //targetP.y=0;
        transform.Translate(targetX + targetY);
    }
    void Start()
    {
        calcular();
    }

    // Update is called once per frame
    void Update()
    {
        towardsTarget = f - transform.position;
        if (towardsTarget.magnitude < 0.25f)
            calcular();
        Quaternion towardsRotation = Quaternion.LookRotation(towardsTarget, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, towardsRotation, rotacionS * Time.deltaTime);
        transform.position += transform.forward * velo * Time.deltaTime;

    }
}


