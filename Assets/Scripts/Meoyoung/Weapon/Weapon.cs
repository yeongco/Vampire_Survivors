using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    private float timer; //총알이 나가는 주기를 위한 변수
    private PlayerController player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        switch (id)
        {
            case 0:
                Vector3 rotationVector = new(0, -1, 0);
                transform.Rotate(rotationVector * speed * Time.deltaTime);
                break;
            default:
                timer += Time.deltaTime;
                if (timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if(id == 0)
        {
            Compose();
        }
    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Compose();
                break;
           
            default:
                speed = 0.3f;
                break;
        }
    }

    void Compose()
    {
        for(int index=0; index<count; index++)
        {
            Transform bullet;

            if(index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = GameManager.instance.pool.GetWeapon(prefabId).transform;
                bullet.parent = transform;
            }
            bullet.localPosition = Vector3.zero; // Bullet 생성전 Position, Roation 초기화
            bullet.localRotation = Quaternion.identity;
            bullet.GetComponent<Bullet>().Init(damage, 1, Vector3.zero); // -1은 무한 관통 무기
        }
    }

    void Fire()
    {
        if (player.scanner.nearestTarget)
        {
            Vector3 targetPos = player.scanner.nearestTarget.position;
            Vector3 dir = targetPos - transform.position;
            dir = dir.normalized;

            Transform bullet = GameManager.instance.pool.GetWeapon(prefabId).transform;
            bullet.position = transform.position;
            bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            bullet.GetComponent<Bullet>().Init(damage, count, dir); // -1은 무한 관통 무기

        }
    }
}
