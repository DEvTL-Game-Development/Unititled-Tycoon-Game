using UnityEngine;

public class cammovement : MonoBehaviour
{
    public float panspeed = 20;
    public float panBorderThickness = 10f;
    public Vector2 panlimit;

    public float scrollSpeed = 20f;
    public float minY = 10f;
    public float maxY = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panspeed * Time.deltaTime; 
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panspeed * Time.deltaTime; 
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panspeed * Time.deltaTime; 
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panspeed * Time.deltaTime; 
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panlimit.x, panlimit.x);
        pos.z = Mathf.Clamp(pos.z, -panlimit.y, panlimit.y);

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
        
    }

}
