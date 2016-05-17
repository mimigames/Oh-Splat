using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    private ObjectStats parentStats;
    private Image healthBar;

    private int health = 0;
    private int maxHealth = 0;

    // Use this for initialization
    void Start() {
        if (transform.FindChild("UnitCanvas").FindChild("HealthBG").FindChild("Health").GetComponent<Image>() != null) {
            healthBar = transform.FindChild("UnitCanvas").FindChild("HealthBG").FindChild("Health").GetComponent<Image>();
        }
        else {
            Debug.LogError("Healthbar is null");
        }
        parentStats = GetComponentInParent<ObjectStats>();

        health = parentStats.health;
        maxHealth = parentStats.maxHealth;
    }

    // Update is called once per frame
    void Update() {

    }

    public enum hitType {
        HEAL,
        DAMAGE
    }

    void Die() {
        Debug.Log(String.Format("{0} Died", gameObject));
        Destroy(gameObject);
    }

    public void ModifyHealth(hitType type, int hitpoints) {
        if (type == hitType.DAMAGE) {
            health -= hitpoints;
            parentStats.health = health;
            if (health <= 0) Die();
        }

        if (type == hitType.HEAL) {
            health += hitpoints;
            if (health > maxHealth) health = maxHealth;
        }

        float fillAmount = ((float)health / maxHealth);
        healthBar.fillAmount = fillAmount;
    }
}
