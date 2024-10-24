using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite crosshair1;
    public Sprite crosshair2;
    public SpriteRenderer spriteRenderer;
    public GameObject crosshairs;
    public GameObject bulletPrefab;
    public Transform shootingPosition;
    public float bulletSpeed = 10f;
    public bool flag = false;
    void Awake()
    {
        spriteRenderer = crosshairs.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = crosshair1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)){
            flag = !flag;
            if (flag) { ChangeCrosshairTo2(); }
            else { ChangeCrosshairTo1(); }
        }
        // Mouse Aiming
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshairs.transform.position = new Vector2(mousePosition.x, mousePosition.y);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Mouse Shooting
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, shootingPosition.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        Vector2 bulletDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootingPosition.position).normalized;
        bulletRb.velocity = bulletDirection * bulletSpeed;
    }
    void ChangeCrosshairTo1()
    {
        spriteRenderer.sprite = crosshair1;
    }
    void ChangeCrosshairTo2()
    {
        spriteRenderer.sprite = crosshair2;
    }
}