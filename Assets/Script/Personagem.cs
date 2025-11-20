using UnityEngine;

public class Personagem : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    [SerializeField] private int vida = 10;
    [SerializeField] private int energia = 100;

    public float getVelocidade()
    {
        return this.velocidade;
    }

    public void setVelocidade(float velocidade)
    {
        this.velocidade = velocidade;
    }

    public int getVida()
    {
        return this.vida;
    }

    public void setVida(int vida)
    {
        this.vida = vida;
    }

    public int getEnergia()
    {
        return this.energia;
    }

    public void setEnergia(int energia)
    {
        this.energia = energia;
    }

}