using UnityEngine;
using System.Collections;

public class PoopScript : MonoBehaviour {
    public float drag;
    public float gravity;
    public float forwardSpeed;

    private float downwardVelocity;

    // Use this for initialization
    void Start() {
        downwardVelocity = gravity;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        transform.Translate(Vector3.down * Time.deltaTime * -Physics.gravity.y);

        downwardVelocity = Mathf.Pow(downwardVelocity, 2);
        forwardSpeed = forwardSpeed * drag;
    }
}
