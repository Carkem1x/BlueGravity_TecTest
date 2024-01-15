using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    #region Variables
    [Header("Player Speed")]
    public float speed = 5f;

    Rigidbody2D rb;
    Animator animator;

    [Header("Menu Player Speed")]
    public GameObject Canvas;
    public GameObject Canvas_Inventory;
    public TextMeshProUGUI CoinText;

    /// <summary>
    /// Sample image within the inventory.
    /// </summary>
    [Header("Inventory Settings")]
    public Image PlayerImage;
    /// <summary>
    /// Sample Name within the inventory.
    /// </summary>
    public TextMeshProUGUI NameSkin;

    /// <summary>
    /// Player skin sprites.
    /// </summary>
    public Sprite[] SourceSkinImage;

    Vector2 movement;

    #endregion
    private void Start()
        {
            PlayerImage.sprite = SourceSkinImage[0];
            NameSkin.text = "Naked";
            CustomizableCharacter.skinNr = 0;

            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }
    
    private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Canvas_Inventory.SetActive(true);
            }

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    
    private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }

    /// <summary>
    /// Modify the player's skin based on the array's value.
    /// </summary>
    /// <param name="x"></param>
    public void Inventory(int x)
    {
        switch (x)
        {
            case 1:
                PlayerImage.sprite = SourceSkinImage[x];
                NameSkin.text = "Girl";
                CustomizableCharacter.skinNr = x;
                break;
            case 2:
                PlayerImage.sprite = SourceSkinImage[x];
                NameSkin.text = "Brown Skin";
                CustomizableCharacter.skinNr = x;
                break;
            case 3:
                PlayerImage.sprite = SourceSkinImage[x];
                NameSkin.text = "Grey Skin";
                CustomizableCharacter.skinNr = x;
                break;
            case 4:
                PlayerImage.sprite = SourceSkinImage[x];
                NameSkin.text = "Knight";
                CustomizableCharacter.skinNr = x;
                break;
        }
    }

    #region OnTriggerRegion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            Canvas.SetActive(true);
        }
        
        if (collision.CompareTag("Gold"))
        {
            ShopManager.Coins += 25;
            CoinText.text = ShopManager.Coins.ToString();
            Destroy(collision.gameObject);
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            Canvas.SetActive(false);
        }
    }

    #endregion
}
