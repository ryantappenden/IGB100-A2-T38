using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Animation swordAnimation;

    // Damage variables
    public float damage = 100.0f;
    public float attackRange = 2.5f;
    public float attackRate = 0.15f;
    private float attackTime;

    // Target object
    public GameObject target;

    // Audio effect
    public GameObject fireSound;

    // Start is called before the first frame update
    void Start()
    {
        swordAnimation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        SwingSword();
    }

    private void SwingSword()
    {
        if (Input.GetMouseButton(0) && Time.time > attackTime)
        {
            //Fire effects
            //Instantiate(fireSound, transform.position, transform.rotation);
            swordAnimation.Play("Slash");

            //Raycast projectile
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -(transform.position - target.transform.position).normalized, out hit, attackRange))
            {
                //Damage enemies
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemy>().takeDamage(damage);
                }
            }

            // Setup next time to attack
            attackTime = Time.time + attackRate;
        }
    }
}
