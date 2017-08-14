
using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool cameraLock = false;
    private float panSpeed = 30f;
    private float panBoardThickness = 10f;
    private float scrollSpeed = 5f;
    private float maxY = 80f;
    private float minY = 20f;
    private int panMaxDistance = 50;
	
	// Update is called once per frame
	void Update () {
        //hit c to lock the camera
        if (Input.GetKeyDown("c"))
        {
            cameraLock = !cameraLock;
        }
        if (cameraLock)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoardThickness)
        {
            if (transform.position.z < panMaxDistance)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBoardThickness)
        {
            if (transform.position.z > -1 * panMaxDistance)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoardThickness)
        {
            if (transform.position.x < panMaxDistance)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBoardThickness)
        {
            if (transform.position.x > -1 * panMaxDistance)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
        }

        //get number of scroll wheel movement.  
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        //adjust y by scroll wheel amount.  *1000 because scroll wheel numbers are very small
        pos.y -= scroll * scrollSpeed * 1000 * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
