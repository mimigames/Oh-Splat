using UnityEngine;
using System.Collections;

public class BirdControls : MonoBehaviour {


    public float forwardSpeed;
    public float strafeSpeed;

    private GameObject body;

    private float horizontalAxis;

    // Use this for initialization
    void Start() {
        body = transform.FindChild("Body").gameObject;
        horizontalAxis = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);

        if (horizontalAxis > 0) {
            body.transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed);
        }
        else if (horizontalAxis < 0) {
            body.transform.Translate(Vector3.left * Time.deltaTime * strafeSpeed);
        }
    }
}
