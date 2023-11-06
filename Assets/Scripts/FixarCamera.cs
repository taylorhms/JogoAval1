using UnityEngine;

public class FixarCamera : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    private Vector3 posicaoInicioDif;

    // Start is called before the first frame update
    void Start()
    {
        posicaoInicioDif = transform.position - jogador.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
                jogador.position.x + posicaoInicioDif.x,
                jogador.position.y + posicaoInicioDif.y,
                transform.position.z);
    }
}
