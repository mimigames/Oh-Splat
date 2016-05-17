using UnityEngine;
using System.Collections;

public class BirdControls : MonoBehaviour {

    public float maxOffCenter;
    public float forwardSpeed;
    public float strafeSpeed;

    private GameObject body;

    private float horizontalAxis;

    // Use this for initialization
    void Start() {
        body = transform.FindChild("Body").gameObject;
    }

    // Update is called once per frame
    void Update() {
        horizontalAxis = Input.GetAxis("Horizontal");

        //Bird flies forwards
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);

        //Strafing
        if (horizontalAxis > 0 && body.transform.position.x < maxOffCenter) {
            body.transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed);
        }
        else if (horizontalAxis < 0 && body.transform.position.x > -maxOffCenter) {
            body.transform.Translate(Vector3.left * Time.deltaTime * strafeSpeed);
        }

        if (Input.GetButtonUp("Horizontal")) {
            body.transform.Translate(Vector3.zero * Time.deltaTime * strafeSpeed);
        }
    }
}
