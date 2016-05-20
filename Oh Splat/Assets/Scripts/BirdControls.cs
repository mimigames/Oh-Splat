using UnityEngine;
using System.Collections;

public class BirdControls : MonoBehaviour {

    public float maxOffCenter;
    public float forwardSpeed;
    public float strafeSpeed;
    public float turnSpeed;

    private GameObject body;
    private GameObject hitBox;

    private float horizontalAxis;

    // Use this for initialization
    void Start() {
        hitBox = transform.FindChild("HitBox").gameObject;
        body = hitBox.transform.FindChild("Body").gameObject;
    }

    // Update is called once per frame
    void Update() {
        horizontalAxis = Input.GetAxis("Horizontal");

        //Bird flies forwards
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);

        //Strafing
        if (horizontalAxis > 0 && hitBox.transform.position.x < maxOffCenter) {
            hitBox.transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed);
        }
        else if (horizontalAxis < 0 && hitBox.transform.position.x > -maxOffCenter) {
            hitBox.transform.Translate(Vector3.left * Time.deltaTime * strafeSpeed);
        }
    }
}
