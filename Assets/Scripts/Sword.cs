using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    enum State
    {
        Idle,
        Attack,
    }

    State state = State.Idle;

    public GameObject Weapon;
    public float attackSpeed = 10.0f;
    private float attackRotation = 0f;
    private float damage = 100.0f;
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            if (!hit)
            {
                StartCoroutine(hittingSequence());
            }
        }



        switch (state)
        {
            case State.Idle:
                attackRotation -= attackSpeed * Time.deltaTime;
                break;
            case State.Attack:
                attackRotation += attackSpeed * Time.deltaTime;
                break;
        }
        attackRotation = Mathf.Clamp01(attackRotation);
        var rotationDegree = Mathf.SmoothStep(0f, 90f, attackRotation);
        Weapon.transform.localRotation = Quaternion.Euler(0f, 120f, rotationDegree);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && state == State.Attack)
        {
            other.GetComponent<Enemy>().takeDamage(damage);
        }
    }

    IEnumerator hittingSequence()
    {
        hit = true;

        state = State.Attack;
        
        yield return new WaitForSeconds(1f / attackSpeed);
        state = State.Idle;
        yield return new WaitForSeconds(1f / attackSpeed);

        hit = false;
    }
}
