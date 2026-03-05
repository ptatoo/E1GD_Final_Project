using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int cash = 100;

    private SpriteRenderer spriteRenderer;

    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    [SerializeField] Sprite sprite3;
    [SerializeField] Sprite sprite4;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (cash == 200)
        {
            spriteRenderer.sprite = sprite2;
        }
        else if (cash == 300)
        {
            spriteRenderer.sprite = sprite3;
        }
        else if (cash == 400)
        {
            spriteRenderer.sprite = sprite4;
        }
        else spriteRenderer.sprite = sprite1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCash() { return cash; }
}
