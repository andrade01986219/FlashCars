using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public GameObject car;
    private Vector3 moveDirection = Vector3.right;
    private float speed = 3.2f;
    public static int position = 0;
    public void MoveCar()
    {
        if (car != null)
        {
            car.transform.position += moveDirection * speed;
            position++;
            FlashCars.UpdateTimer();
            Debug.Log($"Object is at {position}");

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

    private void Boost()
    {
        speed = 3.5f;
    }

    private void ResetSpeed()
    {
        speed = 3.2f;
    }
}
