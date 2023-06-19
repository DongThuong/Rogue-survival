using UnityEngine;

public class BulletController : MonoBehaviour {
    private EnemyHealth enemyHealth;
    public int damage;
    private GameObject explosion;

    void Start() 
    {
        Destroy(gameObject, 4f);
        explosion = Resources.Load<GameObject>("Prefabs/Effects/BulletExplosionEffect1");
    }
    
    // su ken khi va cham voi cac doi tuong khac
    void OnTriggerEnter2D(Collider2D other) 
    {

        // khi cham vao object tag Enemy
        if (other.CompareTag("Enemy")) 
        {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.decreaseHealth(damage);
        }
        // khi cham vao object tag Boss
        if (other.CompareTag("Boss")) 
        {
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            bossHealth.TakeDamage(damage);
        }
        //khi cham vao object tag Hydra
        if (other.CompareTag("Hydra")) 
        {
            HydraHealth bossHealth = other.GetComponent<HydraHealth>();
            bossHealth.TakeDamage(damage);
        }
        // k cham cac tag duoi thi pha huy va sinh ra hieu ung
        if (!other.CompareTag("Player") &&
            !other.CompareTag("PlayerChild") &&
            !other.CompareTag("Bullet") &&
            !other.CompareTag("Hole") &&
            !other.CompareTag("EnemyBullet") &&
            !other.CompareTag("Ignore")) 
        {
            Destroy(gameObject); // pha huy
            Instantiate(explosion, transform.position, transform.rotation); // sinh ra hieu ung
            SoundManager.PlaySound("Explosion"); // phat am thanh hieu ung
        }
    }

    public int Damage 
    {
        get { return damage; }
    }
}
