using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area")) //플레이어가 x축으로 멀어진건지 y축으로 멀어진건지 체크
        {
            Debug.Log("Area 충돌");

            Vector3 playerPos = GameManager.instance.player.transform.position;
            Vector3 myPos = transform.position;

            float diffX = Mathf.Abs(playerPos.x - myPos.x);
            float diffY = Mathf.Abs(playerPos.z - myPos.z);

            Vector3 playerDir = GameManager.instance.player.movement;
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

            if(playerDir.y < 0)
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
                        transform.Translate(Vector3.right * dirX * 200);
                    }
                    else if (diffX < diffY)
                    {
                        Vector3 upVector = new(0, 0, 1);
                        transform.Translate(upVector * dirY * 200);
                    }
                    break;
                case "Enemy":
                    break;
            }
        }
    }
}
