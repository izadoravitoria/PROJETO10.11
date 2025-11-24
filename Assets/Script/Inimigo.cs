using UnityEngine;

public class Inimigo : Personagem
{
    public float raioDeVisao = 1;
    public CircleCollider2D _visaoCollider2D;

    [SerializeField] private Transform posicaoDoPlayer;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool idle = true;
    private bool morto = false;

   public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (posicaoDoPlayer == null)
        {
            posicaoDoPlayer = GameObject.Find("Player").transform;
        }

        raioDeVisao = _visaoCollider2D.radius;
        
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (morto) return;

        idle = true;

        if (getVida() > 0)
        {
            if (posicaoDoPlayer.position.x - transform.position.x > 0)
                spriteRenderer.flipX = false;
            else if (posicaoDoPlayer.position.x - transform.position.x < 0)
                spriteRenderer.flipX = true;

            if (Vector3.Distance(posicaoDoPlayer.position, transform.position) <= raioDeVisao)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    posicaoDoPlayer.position,
                    getVelocidade() * Time.deltaTime
                );

                idle = false;
            }
        }
        else
        {
            Morrer();
        }

       
    }

    private void Morrer()
    {
        morto = true;
        animator.SetTrigger("Morte");
    }

    public void audioplay()
    {
        audioSource.Play();
    }

    public void DestruirInimigo()
    {
        Destroy(gameObject);
    }
}