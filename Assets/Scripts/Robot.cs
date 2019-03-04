using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabRobot = null;

    public GameObject InitialRobot(int positionX, int positionZ, Transform parent)
    {
        if (_prefabRobot == null)
        {
            Debug.LogError("Prefab Robot equals null");
            return new GameObject();
        }
        
        var robot = Instantiate(_prefabRobot, new Vector3(positionX, transform.position.y + 2, positionZ), Quaternion.identity);
        robot.transform.SetParent(parent);

        return robot;
    }
}
