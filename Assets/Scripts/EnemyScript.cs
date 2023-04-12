using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed = 1;
    public float verticalSpeed = 2;
    public Vector2 screenLimit = new(10, 4.03F);
    public float direction = 1;

    public GameObject projectile;
    public Transform[] shootPositions;
    public Vector2 shootDirection = Vector2.right;
    public float shootCD = .8f;
    public float shootSpeed = 300;
    float shootTimer = 0;

    public int maxLife = 10;
    public int life;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start(){
        life = maxLife;
    }

    // Update is called once per frame
    void Update() {
        shootTimer += Time.deltaTime;
        Moviment();
        Shoot();
    }

    public void TakeDamage(int damage = 1)
    {
        if (damage < 0) return;
        life -= damage;
        if (life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
        life = maxLife;
        transform.position = new Vector3(screenLimit.x, 0);
    }
    void Moviment()
    {
        transform.Translate(new Vector2(-speed * Time.deltaTime, direction * speed * verticalSpeed * Time.deltaTime));
        if (transform.position.y > screenLimit.y || transform.position.y < -screenLimit.y) direction *= -1;
        if (transform.position.x < -screenLimit.x) transform.position = new Vector2(screenLimit.x, transform.position.y);
    }

    void Shoot()
    {
        if(shootTimer >= shootCD){
            print("Inimigo Atirando");
            for (int i = 0; i < shootPositions.Length; i++)
            {
                print(i);
                GameObject shoot = Instantiate(projectile);
                shoot.transform.position = shootPositions[i].position;
                shoot.transform.up = shootDirection.normalized;
                shoot.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * shootSpeed);
                shootTimer = 0;
            }
        }
    }

}
