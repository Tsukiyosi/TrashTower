using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassConfigurator : MonoBehaviour
{
    [SerializeField] Vector2 centerOfMass;
    [SerializeField] GameObject dotPrefab;

    Transform dot;

    void FindDot()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "dot")
            {
                dot = child;
                break;
            }
        }
    }

    private void OnValidate()
    {

        FindDot();

        if (dot == null)
        {
            dot = Instantiate(dotPrefab, transform).transform;
            dot.name = "dot";
        }
        dot.localPosition = centerOfMass;
    }

    private void Start()
    {
        FindDot();

        gameObject.GetComponent<Rigidbody2D>().centerOfMass = centerOfMass;

        if (dot != null) Destroy(dot.gameObject);
    }
}
