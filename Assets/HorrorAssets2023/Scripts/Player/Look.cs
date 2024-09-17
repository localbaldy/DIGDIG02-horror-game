using UnityEngine;

public class Look : MonoBehaviour
{
    public float mouseSen = 100f;
    public Transform player;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //L�ser v�r mus till sk�rmen, och s� den inte syns. 
    }
    void Update()
    {
        //H�mtar v�r axis fr�n input manager under project settings
        float mouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;
        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //Vi anv�nder rotate f�r att vi ska kunna stoppa rotationen fr�n att g� f�r l�ngt (max 90 grader)
        player.Rotate(Vector3.up * mouseX);
    }
}

