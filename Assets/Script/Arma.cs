using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform saidaDoTiro;

    public GameObject Bala;

    public float intervaloDisparo = 0;
    private float tempoDeDisparo; 

    private Camera camera;
    public GameObject cursor;
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        camera = Camera.main; 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float camDis = Mathf.Abs(camera.transform.position.z - transform.position.z); 

        Vector3 mouse = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (angle > 90 || angle < -90)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }

        cursor.transform.position = new Vector3(mouse.x, mouse.y, cursor.transform.position.z);

        Debug.DrawLine(transform.position, mouse, Color.red);

        if (tempoDeDisparo <= 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Bala disparada");

            GameObject b = Instantiate(this.Bala, saidaDoTiro.position, saidaDoTiro.rotation) as GameObject;

            tempoDeDisparo = intervaloDisparo;
        }

        if (tempoDeDisparo > 0)
        {
            tempoDeDisparo -= Time.deltaTime;
        }
    }
}