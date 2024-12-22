using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UIElements;


public interface IWeapon
{
    public void Shoot();
}


public class RedLaser : MonoBehaviour, IWeapon 
{
    public float shotSpeed = 1000f;
    public GameObject shootingPoint;

    public void Start()
    {
        shootingPoint = transform.Find("ShootingPoint").gameObject;
    }
    public void Shoot()
    {
        GameObject projectile = Instantiate(Resources.Load("Weapons/RedLaser", typeof(GameObject)), shootingPoint.transform.position, shootingPoint.transform.rotation) as GameObject;
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.velocity = shotSpeed * Time.deltaTime * shootingPoint.transform.up;
        AudioController.PlaySound("RedLaserBlast");
    }
}

public class Rocket_1 : MonoBehaviour,IWeapon
{
    public GameObject shootingPoint;
    public float shotSpeed = 800f;

    public int totalShots = 3;

    public void Start()
    {
        shootingPoint = transform.Find("ShootingPoint").gameObject;

    }
    public void Shoot()
    {
        GameObject projectile = Instantiate(Resources.Load("Weapons/Rocket_1", typeof(GameObject)), shootingPoint.transform.position, shootingPoint.transform.rotation) as GameObject;
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.velocity = shotSpeed * Time.deltaTime * shootingPoint.transform.up;
        AudioController.PlaySound("RocketBlast");

    }
}

public class SniperBullet : MonoBehaviour, IWeapon
{
    public GameObject shootingPoint;
    public float shotSpeed = 500f;
    public void Start()
    {
        shootingPoint = transform.Find("ShootingPoint").gameObject;
    }
    public void Shoot()
    {
        GameObject projectile = Instantiate(Resources.Load("Weapons/SniperBullet") as GameObject, shootingPoint.transform.position, shootingPoint.transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.velocity = shotSpeed * Time.deltaTime * shootingPoint.transform.up;
        AudioController.PlaySound("SniperBulletBlast");
    }
}

public class CannonBullet : MonoBehaviour, IWeapon
{
    public GameObject shootingPoint;
    public float shotSpeed = 400f;
    public void Start()
    {
        shootingPoint = transform.Find("ShootingPoint").gameObject;
    }
    public void Shoot()
    {
        GameObject projectile = Instantiate(Resources.Load("Weapons/CannonBullet") as GameObject, shootingPoint.transform.position, shootingPoint.transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.velocity = shotSpeed * Time.deltaTime * shootingPoint.transform.up;
        AudioController.PlaySound("CannonBulletBlast");
    }
}

public class BalaSimples_1 : MonoBehaviour, IWeapon
{
    public GameObject naveJogador;
    public float intervaloDisparo = 0.5f; 
    public float intensidade = 10f; 
    private bool detectado = false;
    private float tempoDecorrido = 0f; 

    public GameObject shootingPoint;
    public float shotSpeed = 400;

    void Start()
    {

        this.naveJogador = GameObject.FindGameObjectWithTag("Player");
        shootingPoint = transform.Find("ShootingPoint").gameObject;

    }

    

    public void Shoot()
    {
      
        GameObject projectile = Instantiate(Resources.Load("Weapons/BalaSimples") as GameObject, shootingPoint.transform.position, shootingPoint.transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
        rigidbody.velocity = shotSpeed * Time.deltaTime * shootingPoint.transform.up;
        AudioController.PlaySound("SingleBulletBlast");

    }

    

}