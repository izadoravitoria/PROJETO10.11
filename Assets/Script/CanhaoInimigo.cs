using UnityEngine;

public class CanhaoInimigo : MonoBehaviour
{
    [Header("Alvo e Tiro")]
    [SerializeField] private Transform alvo;
    [SerializeField] private Transform pontoDoTiro;

    [Header("Bala")]
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private float velocidadeBala = 15f;
    [SerializeField] private int danoDaBala = 10;

    [Header("Configurações de Disparo")]
    [SerializeField] private float tempoEntreTiros = 2f;

    private float tempo;

    void Update()
    {
        if (alvo == null) return;

        Vector2 direcao = alvo.position - transform.position;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angulo);

        tempo += Time.deltaTime;
        if (tempo >= tempoEntreTiros)
        {
            tempo = 0f;
            Atirar();
        }
    }

    private void Atirar()
    {
        GameObject bala = Instantiate(balaPrefab, pontoDoTiro.position, pontoDoTiro.rotation);
        Bala scriptBala = bala.GetComponent<Bala>();
        if (scriptBala != null)
        {
            scriptBala.setDano(danoDaBala);
        }

        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = pontoDoTiro.right * velocidadeBala;
        }
    }
}