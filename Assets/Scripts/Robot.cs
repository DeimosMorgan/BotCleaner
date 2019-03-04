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
        
        var robot = Instantiate(_prefabRobot, new Vector3(positionX, transform.position.y + 2, positionZ), Quaternion.identity);
        robot.transform.SetParent(parent);

        return robot;
    }

    public Vector3 MoveForward(Vector3 positionBot, Vector3 positionTarget)
    {
        transform.position = positionBot;

        int botX = (int)positionBot.x;
        int botZ = (int)positionBot.z;

        int garbageX = (int)positionTarget.x;
        int garbageZ = (int)positionTarget.z;

        //transform.Translate(0, 0, 1);

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
                Debug.Log("UP");
                transform.Translate(0, 0, 1);
            }
            if (botZ > garbageZ)
            {
                Debug.Log("DOWN");
                transform.Translate(0, 0, -1);
            }
        }

        return transform.position;
    }


    public int FindNearTarget(GameObject[] garbage, int botX, int botZ)
    {
        int[] distance = new int[garbage.Length];
        //Debug.Log("Amount of distance to Bot: " + distance.Length);
        int garbageX;
        int garbageZ;

        for (int i = 0; i < distance.Length; i++)
        {
            garbageX = (int)garbage[i].transform.position.x;
            garbageZ = (int)garbage[i].transform.position.z;

            distance[i] = Mathf.Abs(garbageX - botX) + Mathf.Abs(garbageZ - botZ);
            
            //Debug.Log(distance[i] + " ");
        }

        int minDistance = distance[0];
        int indexMinDistance = 0;

        for (int i = 0; i < distance.Length; i++)
        {
            if (distance[i] < minDistance)
            {
                minDistance = distance[i];
                indexMinDistance = i;
            }
        }
        //Debug.Log("Min distance: " + indexMinDistance);
        //Debug.Log("Position of min distance: " + garbage[indexMinDistance].transform.position);
        
        return indexMinDistance;
    }
}
