using UnityEngine;

public class RotationAxis : MonoBehaviour
{
    public Game gameManager;

    private void Update()
    {
        var point = new Vector3(gameManager.sizeField / 2, gameManager.transform.position.y, gameManager.sizeField / 2);
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(point, Vector3.up, 20 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(point, -Vector3.up, 20 * Time.deltaTime);
        }
    }
}
