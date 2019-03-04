using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabCell = null;

    public GameObject[,] InitialField(int sizeField, Transform parent)
    {
        if (_prefabCell == null)
        {
            Debug.LogError("Prefab Cell equals null");
            return new GameObject[0, 0];
        }

        var parentCells = new GameObject{ name = "Field" };
        var cellsField = new GameObject[sizeField, sizeField];

        for (int i = 0; i < sizeField; i++)
        {
            for (int j = 0; j < sizeField; j++)
            {
                cellsField[i, j] = Instantiate(_prefabCell, new Vector3(i, 0, j), Quaternion.identity);
                cellsField[i, j].transform.SetParent(parentCells.transform);
            }
        }
        parentCells.transform.SetParent(parent);
        return cellsField;
    }
}
