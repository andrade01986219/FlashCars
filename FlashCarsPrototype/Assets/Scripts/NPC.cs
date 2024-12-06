using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject npcCar;   // GameObject attached to the NPC's car
    private Vector3 moveDirection = Vector3.right;
    private float speed = 3.2f;
    public static int position = 0;
    public float interval = 6f;

    private bool isMoving = false;

    public void MoveNPC()
    {
        Debug.Log("MoveNPC button pressed");
        if (!isMoving)
        {
            Debug.Log("Starting Coroutine");
            StartCoroutine(MoveNPCEveryInterval());
        }
    }

    private IEnumerator MoveNPCEveryInterval()
    {
        isMoving = true;
        while (true)
        {
            Debug.Log("Moving car...");
            MoveNPCCar();
            yield return new WaitForSeconds(interval);
        }
    }

    public void MoveNPCCar()
    {
        if (npcCar != null)
        {
            Debug.Log("Moving car by " + (moveDirection * speed));
            npcCar.transform.position += moveDirection * speed;
            position++;
            Debug.Log($"Object is at position {position}");
        }
        else
        {
            Debug.LogError("npcCar is not assigned!");
        }

        if (FlashCars.isWon())
        {
            Debug.Log("NPC has finished the race");
            SceneManager.LoadScene("NPCWinner");
            StopAllCoroutines();
            isMoving = false;
        }
    }

    public static void ResetNPCPosition()
    {
        position = 0;
    }
}
