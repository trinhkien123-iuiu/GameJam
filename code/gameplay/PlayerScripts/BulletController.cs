using UnityEngine;

public class BulletController : MonoBehaviour
{
    Camera mainCam;
    Vector3 direction;
    public float speed = 10f;
    //Không biết, đừng xóa;
    public float diff = -35f;

    void Start()
    {
        mainCam = Camera.main;

        Vector3 mouse = Input.mousePosition;
        mouse.z = -mainCam.transform.position.z;
        Vector3 mousePos = mainCam.ScreenToWorldPoint(mouse);

        direction = (mousePos - transform.position).normalized;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + diff);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
