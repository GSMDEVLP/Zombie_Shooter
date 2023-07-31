using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    public Slider slider;
    private int _health = 100;
    
    void Update()
    {
        slider.value = _health;
        Dead();
    }

    public void TakePlayerDamage(int damage)
    {
        _health -= damage;
    }

    void Dead()
    {
        if(_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
