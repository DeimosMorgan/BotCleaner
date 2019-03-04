using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    public Field fieldManager;
    public Garbage garbageManager;
    public Robot robotManager;

    public int sizeField;
    public Vector2Int posRobot;

    private GameObject[,] _field;
    private GameObject _robot;
    private GameObject[] _garbage;

    private void Start()
    {
        _field = fieldManager.InitialField(sizeField, transform);
        _robot = robotManager.InitialRobot(posRobot.x, posRobot.y, transform);
        _garbage = garbageManager.InitialGarbage(sizeField, transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int botX = (int)transform.position.x;
            int botZ = (int)transform.position.z;

            int indexMinDistance = robotManager.FindNearTarget(_garbage, botX, botZ);
            _robot.transform.position = robotManager.MoveForward(_robot.transform.position, _garbage[indexMinDistance].transform.position);

            if(_robot.transform.position.x == _garbage[indexMinDistance].transform.position.x &&
               _robot.transform.position.z == _garbage[indexMinDistance].transform.position.z &&
               _garbage[indexMinDistance].activeInHierarchy != false)
            {
                _garbage[indexMinDistance].SetActive(false);
            }
        }
        
    }

}
