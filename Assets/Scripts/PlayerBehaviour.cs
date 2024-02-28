using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] WallBehaviour _wallbehaviour;
    public ScoreManager scoreManager;
    public Background  _background;

    public AudioManager audioManager;


    //[SerializeField] GroundCeilingBehaviour _GCbehaviour;
    public bool _isJover = false;
    //[SerializeField] ObjectBehaviour _objBehaviour;

    public bool getJover(){
        return _isJover;
    }
    private float jumpVelocity = 5f;

    private float inputVertical;
    Coroutine x; 
    Coroutine y;
    // Start is called before the first frame update
    void Start()
    {   _rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(_wallbehaviour.SpawnEm());
        x =StartCoroutine(Scores());
        y = StartCoroutine(_background.SpawnEm());
    }

    // Update is called once per frame
   void Update()
{
    // Check if the game is not over
    if (!_isJover)
    {
        //_wallbehaviour.SpawnObject();
        //_GCbehaviour.UUpdate();
        // Handle jump input
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, -jumpVelocity);
        }
        
        // Since _isJover is checked at the beginning, continuous movement
        // is now correctly tied to the game not being over.
        ApplyContinuousRightMovement();

    }
    if (_isJover){
        StopCoroutine(_wallbehaviour.SpawnEm());
        //StopCoroutine(Scores());
        StopCoroutine(x);
        StopCoroutine(y);
        ApplyForceAndDelayRoutine();
        //StopAllCoroutines();
        //_rb.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        //_rb.velocity = new Vector2(0f, _rb.velocity.y); 
        
        Reset();
        scoreManager.scoreText.text = "Game Over";
        
    }

    
}
    public void ApplyForceThenDelay()
    {
        StartCoroutine(ApplyForceAndDelayRoutine());
    }

    IEnumerator ApplyForceAndDelayRoutine()
    {
        // Apply force to the Rigidbody
        //_rb.AddForce(Vector2.right * 2f, ForceMode2D.Impulse);

        // Wait for 200 milliseconds
        yield return new WaitForSeconds(0.5f); // 200ms delay
        // After waiting, set the velocity
        _rb.velocity = new Vector2(0f, _rb.velocity.y);
    }

void ApplyContinuousRightMovement()
{
    // This method is now correctly gated by the _isJover check in Update(),
    // so if you're still seeing continuous movement, ensure _isJover
    // is being set as expected and there are no other calls to this method
    // bypassing the _isJover check.
    _rb.velocity = new Vector2(3f, _rb.velocity.y);
}

void Jump()
{
    // Directly set the vertical velocity for the jump, 
    // preserving the horizontal movement
    _rb.velocity = new Vector2(_rb.velocity.x, jumpVelocity);
    audioManager.PlayWhoosh();
}

    void OnCollisionEnter2D(Collision2D collision)
{
    // Check if the collision is with a GameObject tagged as "Ground"
    if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall")) 
    {
        _rb.velocity = new Vector2 (0f, _rb.velocity.y);
        audioManager.PlaySlap();
        _isJover = true;
    }
}

    void Reset(){
        if(Input.GetKeyDown(KeyCode.Space)) {
            scoreManager.saveHighScore();
            
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
    }
    public IEnumerator Scores(){
        yield return new WaitForSeconds(17/3f);
        while (true){
            audioManager.PlayScore();
            scoreManager.IncreaseScore();
            yield return new WaitForSeconds(5/3f);
        }
    }
}
