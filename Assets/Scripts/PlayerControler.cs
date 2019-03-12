using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rig;

    void Awake (){
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
    }
}
