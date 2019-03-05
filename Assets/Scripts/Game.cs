using UnityEngine;
using System;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public Field fieldManager;
    public Garbage garbageManager;
    public Robot robotManager;

    public int sizeField;
    public Vector2Int posRobot;

    private GameObject[,] _field;
    private GameObject _robot;
    private List<GameObject> _garbage;

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
            int posBotX = (int)_robot.transform.position.x;
            int posBotZ = (int)_robot.transform.position.z;
            int indexNearTarget = robotManager.FindIndexNearTarget(_garbage.ToArray(), posBotX, posBotZ);

            if (indexNearTarget != -1000)
            {
                _robot.transform.position = robotManager.StepToTarget(_robot.transform.position, _garbage[indexNearTarget].transform.position);

                if (_robot.transform.position == _garbage[indexNearTarget].transform.position)
                {
                    _garbage = garbageManager.DestroyGarbage(_garbage, indexNearTarget);
                }
            }
        }

    }

}
