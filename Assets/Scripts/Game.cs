using UnityEngine;

public class Game : MonoBehaviour
{
    public Field fieldManager;
    public Garbage garbageManager;
    public Robot robotManager;

    public int sizeField;
    public Vector2Int posRobot;

    private void Start()
    {
        var field = fieldManager.InitialField(sizeField, transform);
        var robot = robotManager.InitialRobot(posRobot.x, posRobot.y, transform);
        var garbage = garbageManager.InitialGarbage(sizeField, transform);

    }
}
