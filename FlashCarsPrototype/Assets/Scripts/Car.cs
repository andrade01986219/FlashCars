using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public GameObject car;
    private Vector3 moveDirection = Vector3.right;
    private float speed = 3.2f;
    public static int position = 0;
    public int answerButton;
    public void MoveCar()
    {
        if (car != null)
        {
            if (position % 2 == 0)
            {
                if (answerButton == 1)
                {
                    car.transform.position += moveDirection * speed;
                    position++;
                    Debug.Log($"Object is at {position}");
                }
                else
                {
                    Debug.Log($"Wong Answer");
                }
            } else
            {
                if (answerButton == 2)
                {
                    car.transform.position += moveDirection * speed;
                    position++;
                    Debug.Log($"Object is at {position}");
                }
                else
                {
                    Debug.Log($"Wong Answer");
                }
            }

            if (FlashCars.isWon())
            {
                Debug.Log("Car has finshed the race");
                SceneManager.LoadScene("Winner");
            }
        }
        else
        {
            Debug.LogWarning("No object assigned to move.");
        }
    }

    public static void ResetPosition()
    {
        position = 0;
    }
    private void Boost()
    {
        speed = 3.5f;
    }

    private void ResetSpeed()
    {
        speed = 3.2f;
    }
}
