using System;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private int dano = 1;
    [SerializeField] private float velocidade = 1.5f;

    public GameObject explosao;
    
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
        if (colisao.gameObject.CompareTag("Inimigo"))
        {
            
            int novaVida = colisao.gameObject.GetComponent<Personagem>().getVida() - getDano();
            colisao.gameObject.GetComponent<Personagem>().setVida(novaVida);
        }

       
        if (!colisao.gameObject.CompareTag("Player") && !colisao.gameObject.CompareTag("Bala"))
        {
            if (explosao != null)
            {
                ativarExplosao();
            }
            
            Destroy(this.gameObject);
        }

    }
    
      
    public void ativarExplosao()
    {
        explosao.transform.position = transform.position;
        explosao.transform.parent = null;
        explosao.SetActive(true);
    }

}