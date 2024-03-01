using UnityEngine;

public class RandomAttackLaserController : MonoBehaviour
{
    private float speed = 10f;
    private Vector2 direction;

    private float minX = -10f; 
    private float maxX = 10f; 

    public void SetDirection(float angle)
    {
        direction = Quaternion.Euler(0, 0, angle) * Vector2.right;
    }

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        if (transform.position.x > maxX || transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }
}
