using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImmunity : MonoBehaviour
{
    public float immunityDuration = 2f; 
    public LayerMask enemyLayer;
    public LayerMask bulletLayer;

    private Collider2D playerCollider;
    private bool isImmune = false;

    private void Start()
    {

        playerCollider = GetComponent<Collider2D>();
        StartCoroutine(ActivateImmunity());
    }

    private IEnumerator ActivateImmunity()
    {
        isImmune = true;

        Physics2D.IgnoreLayerCollision(gameObject.layer, enemyLayer, true);
        yield return new WaitForSeconds(immunityDuration);

        Physics2D.IgnoreLayerCollision(gameObject.layer, enemyLayer, false);

        isImmune = false;
    }

    public bool IsImmune()
    {
        return isImmune;
    }
}
