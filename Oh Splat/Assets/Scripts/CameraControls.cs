using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraControls : MonoBehaviour {
    public float speed = 1;

    public float edgeSpeed = 1;
    public int scrollDistance = 5;

    public float maxHeight = 10;
    public float minHeight = 5;

    private float horizontalAxis;
    private float verticalAxis;
    private float zoomAxis;
    private Vector2 mousePos;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        zoomAxis = Input.GetAxis("Mouse ScrollWheel");
        mousePos = Input.mousePosition;

        //X and Z movement
        if (!horizontalAxis.Equals(0f) || !verticalAxis.Equals(0f)) {
            float actualSpeed = speed;
            if (!horizontalAxis.Equals(0f) && !verticalAxis.Equals(0f)) {
                actualSpeed = actualSpeed / 2;
            }
            transform.position = new Vector3(
                transform.position.x + (speed * horizontalAxis),
                transform.position.y,
                transform.position.z + (speed * verticalAxis));

        }

        //Camera Edge Scroll
        if (mousePos.x >= Screen.width - scrollDistance)
            transform.position = transform.position = new Vector3(
                transform.position.x + edgeSpeed,
                transform.position.y,
                transform.position.z);
        if (mousePos.x < scrollDistance)
            transform.position = transform.position = new Vector3(
                transform.position.x - edgeSpeed,
                transform.position.y,
                transform.position.z);
        if (mousePos.y >= Screen.height - scrollDistance)
            transform.position = transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + edgeSpeed);
        if (mousePos.y < scrollDistance)
            transform.position = transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z - edgeSpeed);



        //Zoom
        if (zoomAxis < 0f && transform.position.y < maxHeight) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + 1,
                transform.position.z - 0.5f);

        }
        else if (zoomAxis > 0f && transform.position.y > minHeight) {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - 1,
                transform.position.z + 0.5f);
        }
    }
}
