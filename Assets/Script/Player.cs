using UnityEngine;

public class Player : Personagem
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    private bool Andando = false;

    public Transform arma;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        if (arma.rotation.eulerAngles.z > -90 && arma.rotation.eulerAngles.z < 90)
        {
            spriteRenderer.flipX = false;
        }
        
        if (arma.rotation.eulerAngles.z > 90 && arma.rotation.eulerAngles.z < 270)
        {
            spriteRenderer.flipX = true;
        }

        
        bool estaAndando = false;
        
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0,getVelocidade() * Time.deltaTime, 0);
            estaAndando = true;
        }
    
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= new Vector3(0,getVelocidade() * Time.deltaTime, 0);
            estaAndando = true;
        }
    
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(getVelocidade() * Time.deltaTime, 0, 0);
            estaAndando = true;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= new Vector3(getVelocidade() * Time.deltaTime, 0, 0);
            estaAndando = true;
        }
        
        animator.SetBool("Andando", estaAndando);
    }
        
    
}