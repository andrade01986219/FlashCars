using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCar : MonoBehaviour
{
    public GameObject car;
    public Vector3 moveDirection = Vector3.right;
    public float moveDistance = 1f;
    public static int currentPos = 0;
    public void MoveObject()
    {
        if (car != null)
        {
            car.transform.position += moveDirection * moveDistance;
            currentPos++;

            Debug.Log($"Object is at {currentPos}");

            if (currentPos >= 5)
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
}
