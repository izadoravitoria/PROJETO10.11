using System;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private int dano = 1;
    [SerializeField] private float velocidade = 1.5f;
   
    
    private Renderer m_Renderer;

    public void setDano(int dano)
    {
        this.dano = dano;
    }

    public int getDano()
    {
        return this.dano;
    }
    
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Translate(velocidade * Time.deltaTime, 0, 0);

        if (!m_Renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Inimigo"))
        {
            var personagem = colisao.GetComponent<Personagem>();
            personagem.setVida(personagem.getVida() - dano);
        }

        if (colisao.CompareTag("Player"))
        {
            var personagem = colisao.GetComponent<Personagem>();
            personagem.setVida(personagem.getVida() - dano);

            Destroy(gameObject);
            return;
        }

       
    }

    
}