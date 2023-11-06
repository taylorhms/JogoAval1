using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField] private float velocidadeRotacao;
    [SerializeField] private Vector3 direcaoRotacao;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidadeRotacao * direcaoRotacao * Time.deltaTime);
    }
}
