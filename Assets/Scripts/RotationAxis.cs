using UnityEngine;

public class RotationAxis : MonoBehaviour
{
    public Game gameManager;
    public Swipe swipe;

    public float speedRotation = 20f;

    private void Update()
    {
        var point = new Vector3(gameManager.sizeField / 2, gameManager.transform.position.y, gameManager.sizeField / 2);
        if (swipe.SwipeLeft || Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(point, Vector3.up, speedRotation * Time.deltaTime);
        }
        if (swipe.SwipeRight || Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(point, -Vector3.up, speedRotation * Time.deltaTime);
        }
    }
}
