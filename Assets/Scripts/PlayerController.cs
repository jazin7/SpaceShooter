using UnityEngine;
using UnityEngine.UI;  // This is required for UI components

public class PlayerController : MonoBehaviour
{
    private float speed = 8.0f;
    public GameObject laserPrefab;
    public GameObject zigZagLaserPrefab;  // Link this to your laserGreen12 prefab in the inspector
    public GameObject laserBlue04Prefab;  // Link this to your laserPrefab in the inspector
    public GameObject blueLaserPrefab;  // Link this to your laserBlue01 prefab in the inspector

    private float shootingDelay = 0.25f;
    private float maxY;
    private float minY;
    private float timeSinceLastShot = 0f;

    private float specialAttackDelay = 5f;  // Cooldown for the previous special attack
    private float zigZagAttackDelay = 15f;  // Cooldown for the zigzag attack
    private float blueLaserAttackDelay = 20f;  // Cooldown for the blue laser attack
    private float randomAttackDelay = 3f;  // Cooldown for the random attack

    private float timeSinceLastZigZagAttack = -15f;  // Time since last zigzag attack
    private float timeSinceLastBlueLaserAttack = -20f;  // Time since last blue laser attack
    private float timeSinceLastSpecialAttack = -5f;
    private float timeSinceLastRandomAttack = -3f;  // Time since last random attack

    public Image randomAttackCooldownImage;  // Link this to a new UI Image that represents the random attack's cooldown
    public Image blueLaserCooldownImage;  // Link this to a new UI Image that represents the blue laser attack's cooldown
    public Image cooldownImage;  // This should be linked to your UI Image in the inspector
    public Image zigZagCooldownImage;  // Link this to a new UI Image that represents the zigzag attack's cooldown

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float spaceshipHeight = spriteRenderer.bounds.size.y;
        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = screenTop - spaceshipHeight / 2;
        minY = screenBottom + spaceshipHeight / 2;
    }

    private void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetButton("Jump")) && Time.time > timeSinceLastShot + shootingDelay)
        {
            Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            timeSinceLastShot = Time.time;
        }

        if ((Input.GetButton("Fire2") || Input.GetKeyDown(KeyCode.Alpha1)) && Time.time > timeSinceLastSpecialAttack + specialAttackDelay)
        {
            // Shoot three lasers at once
            Instantiate(laserPrefab, transform.position + new Vector3(-0.5f, -0.5f, 0), Quaternion.Euler(0, 0, 0));
            Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            Instantiate(laserPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.Euler(0, 0, 0));
            timeSinceLastSpecialAttack = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > timeSinceLastZigZagAttack + zigZagAttackDelay)
        {
            // all the lasers
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-1.0f, -1.0f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-1.5f, -1.5f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-2.0f, -2.0f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-2.5f, -2.5f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-3.0f, -3.0f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-3.5f, -3.5f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-4.0f, -4.0f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-4.5f, -4.5f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-0.5f, -0.5f, 0), Quaternion.Euler(0, 0, -45));
            Instantiate(zigZagLaserPrefab, transform.position, Quaternion.Euler(0, 0, 270));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.Euler(0, 0, 45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-1.0f, 1.0f, 0), Quaternion.Euler(0, 0, 45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-1.5f, 1.5f, 0), Quaternion.Euler(0, 0, 45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-2.0f, 2.0f, 0), Quaternion.Euler(0, 0, 45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-2.5f, 2.5f, 0), Quaternion.Euler(0, 0, 45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-3.0f, 3.0f, 0), Quaternion.Euler(0, 0, 45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-3.5f, 3.5f, 0), Quaternion.Euler(0, 0, 45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-4.0f, 4.0f, 0), Quaternion.Euler(0, 0, 45));
            Instantiate(zigZagLaserPrefab, transform.position + new Vector3(-4.5f, 4.5f, 0), Quaternion.Euler(0, 0, 45));
            timeSinceLastZigZagAttack = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > timeSinceLastBlueLaserAttack + blueLaserAttackDelay)
        {
            // Calculate the y range
            float screenHeight = Camera.main.orthographicSize * 2.0f;
            float screenWidth = screenHeight * Screen.width / Screen.height;
            float yTop = Camera.main.transform.position.y + screenHeight / 2;
            float yBottom = Camera.main.transform.position.y - screenHeight / 2;

            float spacing = screenWidth / 50; // assuming we want to spawn 50 lasers

            for (int i = 0; i < 50; i++)
            {
                // top lasers
                Vector3 topPos = new Vector3(Camera.main.transform.position.x - screenWidth / 2 + i * spacing, yTop, 0);
                GameObject topLaser = Instantiate(blueLaserPrefab, topPos, Quaternion.Euler(0, 0, 180));
                topLaser.GetComponent<BlueLaserController>().Speedx = -speed;  // Making it go downwards

                // bottom lasers
                Vector3 bottomPos = new Vector3(Camera.main.transform.position.x - screenWidth / 2 + i * spacing, yBottom, 0);
                GameObject bottomLaser = Instantiate(blueLaserPrefab, bottomPos, Quaternion.identity);
                bottomLaser.GetComponent<BlueLaserController>().Speedx = speed;  // Making it go upwards
            }

            timeSinceLastBlueLaserAttack = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && Time.time > timeSinceLastRandomAttack + randomAttackDelay)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject laser = Instantiate(laserBlue04Prefab, transform.position, Quaternion.identity);
                float randomAngle = UnityEngine.Random.Range(-45, 45);
                laser.GetComponent<RandomAttackLaserController>().SetDirection(randomAngle);
            }

            timeSinceLastRandomAttack = Time.time;
        }


        // Update the UI to represent the cooldowns
        float cooldownProgress = (Time.time - timeSinceLastSpecialAttack) / specialAttackDelay;
        cooldownImage.fillAmount = cooldownProgress;

        float zigZagCooldownProgress = (Time.time - timeSinceLastZigZagAttack) / zigZagAttackDelay;
        zigZagCooldownImage.fillAmount = zigZagCooldownProgress;

        float blueLaserCooldownProgress = (Time.time - timeSinceLastBlueLaserAttack) / blueLaserAttackDelay;
        blueLaserCooldownImage.fillAmount = blueLaserCooldownProgress;

        float randomAttackCooldownProgress = (Time.time - timeSinceLastRandomAttack) / randomAttackDelay;
        randomAttackCooldownImage.fillAmount = randomAttackCooldownProgress;

    }


    private void FixedUpdate()
    {
        float moveY = Input.GetAxis("Vertical");
        Vector3 newPosition = transform.position + new Vector3(0, moveY, 0) * speed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }
}
