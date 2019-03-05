using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public static int amountStepsBot;
    public static bool isOver;

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
        ResetData();
    }

    public void Initialize(InputField inputField)
    {
        int tempSizeField = int.Parse(inputField.text);
        if (tempSizeField >= 2 && tempSizeField <= 50)
        {
            sizeField = tempSizeField;
            if (_field != null || _robot != null || _field != null)
            {
                Destroy(_robot);
                foreach (var cur in _garbage) { Destroy(cur); }
                foreach (var cur in _field) { Destroy(cur); }
            }
            _field = fieldManager.InitialField(tempSizeField, transform);
            _robot = robotManager.InitialRobot(posRobot.x, posRobot.y, transform);
            _garbage = garbageManager.InitialGarbage(tempSizeField, transform);
        }
    }
    public void Clean()
    {
        StartCoroutine(IEClean());
    }

    public void ResetData()
    {
        amountStepsBot = 0;
        isOver = false;
    }

    private IEnumerator IEClean()
    {

        while (true)
        {
            int posBotX = (int)_robot.transform.position.x;
            int posBotZ = (int)_robot.transform.position.z;
            int indexNearTarget = robotManager.FindIndexNearTarget(_garbage.ToArray(), posBotX, posBotZ);

            if (indexNearTarget != -1000)
            {
                _robot.transform.position = robotManager.StepToTarget(_robot.transform.position, _garbage[indexNearTarget].transform.position);

                int posGarbageX = (int)_garbage[indexNearTarget].transform.position.x;
                int posGarbageZ = (int)_garbage[indexNearTarget].transform.position.z;

                if (posBotX == posGarbageX && posBotZ == posGarbageZ)
                {
                    _garbage = garbageManager.DestroyGarbage(_garbage, indexNearTarget);
                }

                yield return new WaitForSecondsRealtime(1f);
            }
            else
            {
                isOver = true;
                break;
            }
        }
    }
}
