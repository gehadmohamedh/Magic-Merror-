using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerareflection : MonoBehaviour
{
    public Transform MirrorCamLeft;
    public Transform MirrorCamRight;
    public Camera  cam ;
    public Transform PlayerCamLeft;
    public Transform PlayerCamRight;
    // Update is called once per frame
    private void Update()
    {
       CalculateRotation();
    }
   
    public void CalculateRotation() 
    {
        Vector3 directionLeft = (PlayerCamLeft.position - transform.position);
        Vector3 directionRight = (PlayerCamRight.position - transform.position);
        Quaternion rotationLeft = Quaternion.LookRotation(directionLeft);
        Quaternion rotationRight = Quaternion.LookRotation(directionRight);
        rotationLeft.eulerAngles= transform.eulerAngles - rotationLeft.eulerAngles;
        rotationRight.eulerAngles = transform.eulerAngles - rotationRight.eulerAngles;
        MirrorCamLeft.localRotation = rotationLeft;
        MirrorCamRight.localRotation = rotationRight;
        float newrotLeft = transform.rotation.z - rotationLeft.eulerAngles.z ;
        float newroRight = transform.rotation.z - rotationRight.eulerAngles.z;
        MirrorCamLeft.Rotate(0 , 0 , newrotLeft);
        MirrorCamRight.Rotate(0, 0, newroRight);
       /* Vector3 offsetLeft = PlayerCamLeft.position - transform.position;
        Vector3 offsetRight = PlayerCamRight.position - transform.position;
        offsetLeft.z *= -1;
        offsetRight.z *= -1;
        offsetLeft.x *= -1;
        offsetRight.x *= -1;
        MirrorCamLeft.position = transform.position + offsetLeft;
        MirrorCamRight.position = transform.position + offsetRight;*/
    }
}
 