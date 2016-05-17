using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectStats : MonoBehaviour {

    public int health, maxHealth, movementSpeed, damage, armor;
    private Health healthBar;

    public int CurrentHealth {
        get { return health; }
    }

    // Use this for initialization
    void Start() {
        if (gameObject.GetComponent<Health>() != null) healthBar = transform.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void buttonHit(int damage) {
        healthBar.ModifyHealth(Health.hitType.DAMAGE, damage);
    }

    public void buttonHeal(int damage) {
        healthBar.ModifyHealth(Health.hitType.HEAL, damage);
    }

    public void Hit(Health.hitType type, int hitPoints) {
        healthBar.ModifyHealth(type, hitPoints);
    }
}
