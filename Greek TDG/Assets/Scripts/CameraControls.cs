using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraControls : MonoBehaviour {
    public float speed = 1;
    public float maxHeight = 10;
    public float minHeight = 5;

    private float horizontalAxis;
    private float verticalAxis;
    private float zoomAxis;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        zoomAxis = Input.GetAxis("Mouse ScrollWheel");

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
