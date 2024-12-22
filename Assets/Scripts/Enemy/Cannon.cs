using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public string playerTag = "Player";

    private GameObject jogador;
    private Vector2 direcao;

    public float velocidade = 5f;
    public GameObject prefab;
    public GameObject naveJogador;
    public float tempoDisparo = 1f;
    private bool detectado = false;
    public AudioSource somDisparo;

    public float nextFire = 0.0f;
    public float fireRate = 0.3f;

    public IWeapon primaryWeapon;

    public float anguloMaximo;

    //Enemy life
    public float life = 50;

    // Start is called before the first frame update
    void Start()
    {
        this.primaryWeapon = gameObject.AddComponent<CannonBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        jogador = GameObject.FindGameObjectWithTag(playerTag);
        if (jogador != null)
        {
            direcao = jogador.transform.position - transform.position;
            transform.up = direcao.normalized;
            if (Time.time > nextFire && VerifyAttackRadius())
            {
                nextFire = Time.time + fireRate;
                primaryWeapon.Shoot();
            }
        }
    }


    public bool VerifyAttackRadius()
    {
        Vector3 direcaoJogador = jogador.transform.position - transform.position;
        float angulo = Vector3.Angle(transform.up, direcaoJogador);
        if (angulo > anguloMaximo)
            return true;
        else
            return false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManagerCollision(collision);
    }


    private void ManagerCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            this.life -= 1;
            if (life == 0)
            {
                Instantiate(Resources.Load("Effects/ExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
                AudioController.PlaySound("Explosion");
                int currentRoom = GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom;
                if (currentRoom == 1)
                {
                    GameObject.FindGameObjectWithTag("FirstRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 2)
                {
                    GameObject.FindGameObjectWithTag("SecondRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 3)
                {
                    GameObject.FindGameObjectWithTag("ThirdRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 4)
                {
                    GameObject.FindGameObjectWithTag("FourthRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 5)
                {
                    GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("RocketExplosion"))
        {
            Debug.Log("Explos�o");
            this.life -= 40;
            if (life <= 0)
            {
                Instantiate(Resources.Load("Effects/ExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
                AudioController.PlaySound("Explosion");
                int currentRoom = GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom;
                if (currentRoom == 1)
                {
                    GameObject.FindGameObjectWithTag("FirstRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 2)
                {
                    GameObject.FindGameObjectWithTag("SecondRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 3)
                {
                    GameObject.FindGameObjectWithTag("ThirdRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 4)
                {
                    GameObject.FindGameObjectWithTag("FourthRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 5)
                {
                    GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                Destroy(this.gameObject);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.life = 0;

            Instantiate(Resources.Load("Effects/ExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
            AudioController.PlaySound("Explosion");

            int currentRoom = GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom;
            if (currentRoom == 1)
            {
                GameObject.FindGameObjectWithTag("FirstRoom").GetComponent<RoomController>().EnemyDefeated();
            }
            else if (currentRoom == 2)
            {
                GameObject.FindGameObjectWithTag("SecondRoom").GetComponent<RoomController>().EnemyDefeated();
            }
            else if (currentRoom == 3)
            {
                GameObject.FindGameObjectWithTag("ThirdRoom").GetComponent<RoomController>().EnemyDefeated();
            }
            else if (currentRoom == 4)
            {
                GameObject.FindGameObjectWithTag("FourthRoom").GetComponent<RoomController>().EnemyDefeated();
            }
            else if (currentRoom == 5)
            {
                GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().EnemyDefeated();
            }

            Destroy(this.gameObject);
        }
    }
}
