using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    [Tooltip("살아있는 물체의 collider만 활성화 시키기 위함")]
    [SerializeField] Collider coll;

    private void Awake()
    {
        coll = GetComponent<Collider>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area")) //플레이어가 x축으로 멀어진건지 y축으로 멀어진건지 체크
        {
            //Debug.Log("Area 충돌");
           //ebug.Log(transform.tag);

            Vector3 playerPos = GameManager.instance.player.transform.position;
            Vector3 myPos = transform.position;

            float diffX = Mathf.Abs(playerPos.x - myPos.x);
            float diffY = Mathf.Abs(playerPos.z - myPos.z);

            Vector3 playerDir = new(GameManager.instance.player.movement.x, 0f, GameManager.instance.player.movement.y);
            float dirX = 0;
            float dirY = 0; 
            if (playerDir.x < 0)
            {
                dirX = -1;
            }
            else
            {
                dirX = 1;
            }

            if(playerDir.z < 0)
            {
                dirY = -1;
            }
            else
            {
                dirY = 1;
            }

            switch (transform.tag)
            {
                case "Ground":
                    Debug.Log("Tag : Ground");
                    if(diffX > diffY)
                    {
                        Debug.Log("X축 이동");
                        transform.Translate(Vector3.right * dirX * 200);
                    }
                    else if (diffX < diffY)
                    {
                        Debug.Log("Y축 이동");
                        Vector3 upVector = new(0, 0, 1);
                        transform.Translate(upVector * dirY * 200);
                    }
                    break;
                case "Enemy":
                    Debug.Log("Tag : Enemy");
                    if (coll.enabled)
                    {
                        //Debug.Log("Moving enemy in direction: " + playerDir);
                        transform.Translate(playerDir * 100 + new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3f, 3f)), Space.World); //플레이어가 바라보는 방향에서 다시 생성
                    }
                    break;
            }
        }
    }
}
