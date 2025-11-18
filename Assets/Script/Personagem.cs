using UnityEngine;

public class Personagem : MonoBehaviour
{
  
    [SerializeField] private float Velocidade = 3;
    [SerializeField] public int Vida = 10;
    [SerializeField] public int Energia = 100;

    public float getVelocidade()
    {
        return this.Velocidade;
    }

    public void setVelocidade(float velocidade)
    {
        this.Velocidade = velocidade;
    }



    public int getVida()
    {
        return this.Vida;
    }

    public void setVida(int vida)
    {
       
        this.Vida = vida;
    }

    public int getEnergia()
    {
        return this.Energia;
    }

    public void setEnergia(int energia)
    {
       
        this.Energia = energia;
    }

}
