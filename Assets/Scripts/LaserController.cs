using UnityEngine;

public class LaserController : MonoBehaviour
{
    private float speed = 10f;
    private float maxX = 10f;

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        // Destroy the laser when it leaves the screen
        if (transform.position.x > maxX)
        {
            Destroy(gameObject);
        }
    }
}
