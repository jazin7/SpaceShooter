using UnityEngine;

public class RandomAttackLaserController : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 direction;

    private float minX = -10f; // Define the minimum x boundary
    private float maxX = 10f; // Define the maximum x boundary

    public void SetDirection(float angle)
    {
        direction = Quaternion.Euler(0, 0, angle) * Vector2.right;
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        // Destroy the laser when it leaves the screen
        if (transform.position.x > maxX || transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }
}
