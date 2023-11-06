using TMPro;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    [SerializeField] private float velocidadeMovimento;
    [SerializeField] private float velocidadeSalto;
    [SerializeField] private LayerMask layerMoedas;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    private Vector3 posicaoInicio;
    private Quaternion rotacaoInicio;
    private Rigidbody rb;
    private float eixoHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        posicaoInicio = transform.position;
        rotacaoInicio = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        eixoHorizontal = Input.GetAxis("Horizontal");

        if (Physics.OverlapBox(transform.position, transform.localScale).Length > 0
            && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(velocidadeSalto * Vector3.up, ForceMode.VelocityChange);
        }

        rb.velocity = new Vector3(eixoHorizontal * velocidadeMovimento, rb.velocity.y, 0);

        // Reseta a posicao clicando em K
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position = posicaoInicio;
            transform.rotation = rotacaoInicio;
            rb.velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Moeda"))
        {
            Destroy(other.gameObject);
            score += 1;
            scoreText.text = "Score: " + score;
        }
    }
}
