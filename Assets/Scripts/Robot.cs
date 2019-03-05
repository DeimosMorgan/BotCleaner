using UnityEngine;
using System;

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
        
        var robot = Instantiate(_prefabRobot, new Vector3(positionX, _prefabRobot.transform.position.y, positionZ), Quaternion.identity);
        robot.transform.SetParent(parent);

        return robot;
    }

    public Vector3 StepToTarget(Vector3 positionBot, Vector3 positionTarget)
    {
        transform.position = positionBot;

        int botX = (int)positionBot.x;
        int botZ = (int)positionBot.z;

        int garbageX = (int)positionTarget.x;
        int garbageZ = (int)positionTarget.z;

        if (botX < garbageX)
        {
            Debug.Log("RIGHT");
            transform.Translate(1, 0, 0);
        }
        if (botX > garbageX)
        {
            Debug.Log("LEFT");
            transform.Translate(-1, 0, 0);
        }
        if (botX == garbageX)
        {
            if (botZ < garbageZ)
            {
                Debug.Log("Forward");
                transform.Translate(0, 0, 1);
            }
            if (botZ > garbageZ)
            {
                Debug.Log("Backward");
                transform.Translate(0, 0, -1);
            }
        }

        return transform.position;
    }

    public int FindIndexNearTarget(GameObject[] garbage, int posBotX, int posBotZ)
    {
        if(garbage.Length == 0)
        {
            Debug.Log("Bot cleaned field from garbage!");
            return -1000;
        }
        int[] distance = new int[garbage.Length];
        int garbageX;
        int garbageZ;

        for (int i = 0; i < distance.Length; i++)
        {
            garbageX = (int)garbage[i].transform.position.x;
            garbageZ = (int)garbage[i].transform.position.z;
            distance[i] = Mathf.Abs(garbageX - posBotX) + Mathf.Abs(garbageZ - posBotZ);
        }

        int indexMinDistance = UnityEngine.Random.Range(0, distance.Length);
        int minDistance = distance[indexMinDistance];

        for (int i = 0; i < distance.Length; i++)
        {
            if (distance[i] < minDistance)
            {
                minDistance = distance[i];
                indexMinDistance = i;
            }
        }
        
        return indexMinDistance;
    }
}