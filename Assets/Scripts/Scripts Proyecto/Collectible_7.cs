using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_7 : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {

            gameManager.AddCollectible();
            Destroy(gameObject);
        }
    }
}
