using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public  GameObject npcCar;   // gameObject attached to npc's car
    private  Vector3 moveDirection = Vector3.right;
    private  float speed = 3.2f;
    public  static int position = 0;
    public  float interval = 4f;
    public  float timeElapsed = 0f;
    bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartMovement();
    }

    public  void MoveNPC()
    {

            // incr time by time passed since last frame
            timeElapsed += Time.deltaTime;

            // check if we hit interval
            if (timeElapsed >= interval)
            {
                // move car
                MoveNPCCar();

                // reset time
                timeElapsed = 0f;
            }
        
    }

    public  void MoveNPCCar()
    {
        if (npcCar != null)
        {
            npcCar.transform.position += moveDirection * speed;
            position++;
            Debug.Log($"Object is at {position}");
        }

        // check if NPC has won
        if (FlashCars.isWon())
        {
            Debug.Log("NPC has finished race");
            SceneManager.LoadScene("Winner");
        }
        
    }

    public void StartMovement()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveNPC();
    }
}
