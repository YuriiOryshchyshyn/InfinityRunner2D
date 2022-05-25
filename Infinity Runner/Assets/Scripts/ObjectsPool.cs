using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject result = Instantiate(prefab, _container.transform).gameObject;
            result.SetActive(false);
            _pool.Add(result);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(obj => obj.activeSelf == false);

        return result != null;
    }
}
