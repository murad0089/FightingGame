using UnityEngine;
using System.Collections;
using System;

public class Sensor_Bandit : MonoBehaviour {

    private Animator animator;
    private int m_ColCount = 0;
    public int maxHealth = 100;
    int currentHealth;
    private float m_DisableTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;

        if(currentHealth < 0)
        {
            animator.SetTrigger("Death");
            Debug.Log("enemy died");
        }
    }
    private void OnEnable()
    {
        m_ColCount = 0;
    }

    public bool State()
    {
        if (m_DisableTimer > 0)
            return false;
        return m_ColCount > 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        m_ColCount++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        m_ColCount--;
    }

    void Update()
    {
        m_DisableTimer -= Time.deltaTime;
    }

    public void Disable(float duration)
    {
        m_DisableTimer = duration;
    }

}
