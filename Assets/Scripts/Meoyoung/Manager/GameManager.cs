using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime; //게임시간을 측정하기위한 변수
    public float maxGameTime = 2 * 10f; //최대 게임 시간

    public PlayerController player;
    public PoolManager pool;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
