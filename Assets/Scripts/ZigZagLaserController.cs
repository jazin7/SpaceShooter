using UnityEngine;

public class ZigZagLaserController : MonoBehaviour
{
    private float speed = 5f;
    private float maxX = 10f;

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (transform.position.x > maxX)
        {
            Destroy(gameObject);
        }
    }
}
