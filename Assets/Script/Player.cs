using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Personagem
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
   
    private bool andando = false;

    public GameObject[] armas;

    private GameObject armaAtual;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        armaAtual = armas[0];
        armaAtual.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            armaAtual.SetActive(false);
            armaAtual = armas[0];
            armaAtual.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            armaAtual.SetActive(false);
            armaAtual = armas[1];
            armaAtual.SetActive(true);
        }


        andando = false;

        if (armaAtual.transform.rotation.eulerAngles.z > -90 && armaAtual.transform.rotation.eulerAngles.z < 90)
        {
            spriteRenderer.flipX = false;
        }
        
        if (armaAtual.transform.rotation.eulerAngles.z > 90 && armaAtual.transform.rotation.eulerAngles.z < 270)
        {
            spriteRenderer.flipX = true;
        }

        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, getVelocidade() * Time.deltaTime, 0);
            andando = true;
        }
        
        if(Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= new Vector3(0, getVelocidade() * Time.deltaTime, 0);
            andando = true;
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(getVelocidade() * Time.deltaTime, 0, 0);
            andando = true;
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= new Vector3(getVelocidade() * Time.deltaTime, 0, 0);
            andando = true;
        }
        
        animator.SetBool("Andando", andando);

        if (getVida() <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}