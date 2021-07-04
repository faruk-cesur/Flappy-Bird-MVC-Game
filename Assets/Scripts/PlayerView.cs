using UnityEngine;

// (MVC Design Pattern) - View Burada tutuluyor.
public class PlayerView : MonoBehaviour
{
    public Rigidbody2D rb;
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameManager.gameManager._playerController;
        rb = GetComponent<Rigidbody2D>();
    }


    // Oyun başlangıç aşamasında tap to start ile MainGame durumuna geçiş yapıyoruz.
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameManager.CurrentGameState != GameManager.GameState.GameOver)
        {
            GameManager.gameManager.CurrentGameState = GameManager.GameState.MainGame;
        }

        _playerController.ChangeGameState();
    }


    // Tıklama inputu alır ve karşılığında controllerdan zıplama metodu çağırır.
    public void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerController.Jumping();
        }
    }


    // Karakterimiz her hangi bir şeye çarparsa GameOver oyun durumuna geçiş yapılır.
    public void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.gameManager.CurrentGameState = GameManager.GameState.GameOver;
    }


    // Karakterimiz obstacle objelerin arasından geçtiği zaman puan kazanır.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreArea")) ;
        {
            _playerController.EarnScore();
        }
    }
}