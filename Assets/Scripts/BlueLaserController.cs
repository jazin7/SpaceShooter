using UnityEngine;

public class BlueLaserController : MonoBehaviour
{
    public float Speedx { get; set; } = 8f;
    private float maxY = 10f;
    private float minY = -10f;

    void Update()
    {
        transform.position += new Vector3(0, Speedx * Time.deltaTime, 0);

        // Destroy the laser when it leaves the screen
        if (transform.position.y > maxY || transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
