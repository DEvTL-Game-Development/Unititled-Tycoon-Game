using UnityEngine;

public class cammovement : MonoBehaviour
{
    [SerializeField]
    private float panSpeed = 20f;
    [SerializeField]
    private float panBorderThickness = 10f;
    [SerializeField]
    private float scrollSpeed = 20f;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private float rotationX;
    [SerializeField]
    private float rotationY;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime; 
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime; 
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime; 
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime; 
        }

        if (Input.GetKey("q"))
        {
            Rotation();
        }

        transform.position = pos;

        Zoom();
        
    }

    ///<summary>
    ///zoom in camera with the scroll wheel
    ///<summary>
    private void Zoom()
    {
        camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
    }
    ///<summary>
    ///rotate the camera by holding Q and moving the mouse
    ///<summary>
    private void Rotation()
    {
        rotationX += Input.GetAxis("Mouse X") * Time.deltaTime * panSpeed * 100f;
        rotationY += Input.GetAxis("Mouse Y") * Time.deltaTime * panSpeed * 100f;
        rotationY = Mathf.Clamp(rotationY, -30, 90);
        transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
    }

}
