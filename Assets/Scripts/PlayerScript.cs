using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour{

    public float speed = 1;
    public Vector2 screenLimit = new Vector2(8.3F, 5.45F);
    public GameObject projectile;
    public Transform[] shootPositions;
    public Vector2 shootDirection = new(1,0);
    public float shootCD = .5f;
    public float shootSpeed = 300;
    float shootTimer = 0;
    public int maxLife = 10;
    public int life;
    public Image lifeBar;
    public TextMeshProUGUI lifeInfo;
    public TextMeshProUGUI scoreInfo;
    public int score = 0;
    private float gameTime = 0;
    public float boost = 1;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start(){
        life = maxLife;
        UpdateUI();
    }

    // Update is called once per frame
    void Update(){
        UpdateUI();
        gameTime += Time.deltaTime;
        shootTimer += Time.deltaTime;
        Moviment();
        Shoot();
    }

    public void AddScore(int value = 20)
    {
        this.score += value;
    }

    public void UpdateUI()
    {
        lifeBar.fillAmount = (float)life / maxLife;
        lifeInfo.text = life + "/" + maxLife;
        scoreInfo.text = "Score: " + ((int) gameTime + score);
        if(score != 0) print(score);
    }

    public void TakeDamage(int damage = 1)
    {
        if (damage < 0) return;
        life -= damage;
        if(life <= 0)
        {
            Die();
        }
        UpdateUI();
    }

    void Die()
    {
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
        life = maxLife;
        transform.position = new Vector3(0, 0);
    }

    void Shoot(){
        if (Input.GetAxisRaw("Jump") != 0 && shootTimer >= shootCD){
            for(int i = 0; i < shootPositions.Length; i++){
                GameObject shoot = Instantiate(projectile);
                shoot.transform.position = shootPositions[i].position;
                shoot.transform.up = shootDirection.normalized;
                shoot.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * shootSpeed);
                shootTimer = 0;
            }
        }
    }

    void Moviment(){
        float hMove = Input.GetAxisRaw("Horizontal");
        float vMove = Input.GetAxisRaw("Vertical");
        transform.Translate(speed * Time.deltaTime * new Vector3(hMove, vMove).normalized);
        if (transform.position.x > screenLimit.x) transform.position = new Vector3(screenLimit.x, transform.position.y);
        if (transform.position.x < -screenLimit.x) transform.position = new Vector3(-screenLimit.x, transform.position.y);
        if (transform.position.y > screenLimit.y) transform.position = new Vector3(transform.position.x, -screenLimit.y + .2f);
        if (transform.position.y < -screenLimit.y) transform.position = new Vector3(transform.position.x, screenLimit.y - .2f);
    }

}
