using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Array of purchased items in the inventory
    /// </summary>
    public GameObject[] ItemsInInvetary;
    /// <summary>
    /// Array of items available for purchase in the store
    /// </summary>
    public GameObject[] StockInShop;
    /// <summary>
    /// Images when an item is not available in the store
    /// </summary>
    public GameObject[] OutOfStock;

    /// <summary>
    /// Array of items that can be sold from the inventory
    /// </summary>
    public GameObject[] InventoryToSell;
    /// <summary>
    /// Array of character images for item sale
    /// </summary>
    public Sprite[] ImageOfCharacterToSell;

    /// <summary>
    /// Sample image
    /// </summary>
    [Header("Sell Settings")]
    public Image CharacterToSell;
    /// <summary>
    /// Item price text
    /// </summary>
    public TextMeshProUGUI PriceToSell_Text;
    /// <summary>
    /// Item name text
    /// </summary>
    public TextMeshProUGUI NameToSell_Text;

    /// <summary>
    /// Sample image object
    /// </summary>
    public GameObject PlayerImageToSell;
    /// <summary>
    /// Confirmation purchase text
    /// </summary>
    public GameObject Text_Sold;
    int valueItem;
    /// <summary>
    /// Sold item background object
    /// </summary>
    [Header("Sell Show Item")]
    public GameObject ShowItem;

    /// <summary>
    /// Money amount text
    /// </summary>
    [Header("Money Settings")]
    public TextMeshProUGUI CoinText;
    /// <summary>
    /// Notification that you don't have enough money to purchase the item
    /// </summary>
    public GameObject WarningNoMoney;
    public static int Coins = 100;

    /// <summary>
    /// Sample image in the inventory
    /// </summary>
    [Header("Player Inventory")]
    public Image PlayerImage;
    /// <summary>
    /// Skin name in the inventory
    /// </summary>
    public TextMeshProUGUI NameSkin;
    #endregion

    void Start()
    {
        CoinText.text = Coins.ToString();
    }

    #region Functions Store
    /// <summary>
    /// Item purchasing system
    /// </summary>
    /// <param name="NumberItem"></param>
    public void BuyItem(int NumberItem)
    {
        switch (NumberItem)
        {
            case 0:
                if(Coins >= 25)
                {
                    Coins -= 25;
                    CoinText.text = Coins.ToString();
                    ItemsInInvetary[NumberItem].SetActive(true); //inventario de player
                    StockInShop[NumberItem].SetActive(false); //Item de tienda
                    OutOfStock[NumberItem].SetActive(true); //Anuncio de stock
                    InventoryToSell[NumberItem].SetActive(true); //inventario para vender
                }
                else
                {
                    StartCoroutine(Timer(2));
                }
                
                break;
            case 1:
                if (Coins >= 40)
                {
                    Coins -= 40;
                    CoinText.text = Coins.ToString();
                    ItemsInInvetary[NumberItem].SetActive(true); //inventario de player
                    StockInShop[NumberItem].SetActive(false); //Item de tienda
                    OutOfStock[NumberItem].SetActive(true); //Anuncio de stock
                    InventoryToSell[NumberItem].SetActive(true); //inventario para vender
                }
                else
                {
                    StartCoroutine(Timer(2));
                }
                break;
            case 2:
                if (Coins >= 60)
                {
                    Coins -= 60;
                    CoinText.text = Coins.ToString();
                    ItemsInInvetary[NumberItem].SetActive(true); //inventario de player
                    StockInShop[NumberItem].SetActive(false); //Item de tienda
                    OutOfStock[NumberItem].SetActive(true); //Anuncio de stock
                    InventoryToSell[NumberItem].SetActive(true); //inventario para vender
                }
                else
                {
                    StartCoroutine(Timer(2));
                }
                break;
            case 3:
                if (Coins >= 100)
                {
                    Coins -= 100;
                    CoinText.text = Coins.ToString();
                    ItemsInInvetary[NumberItem].SetActive(true); //inventario de player
                    StockInShop[NumberItem].SetActive(false); //Item de tienda
                    OutOfStock[NumberItem].SetActive(true); //Anuncio de stock
                    InventoryToSell[NumberItem].SetActive(true); //inventario para vender
                }
                else
                {
                    StartCoroutine(Timer(2));
                }
                break;
        }
    }

    /// <summary>
    /// Item selling system
    /// </summary>
    /// <param name="NumberItem"></param>
    public void SelectItemForSell(int NumberItem)
    {
        ShowItem.SetActive(true);
        PlayerImageToSell.SetActive(true);
        switch (NumberItem)
        {
            case 0:
                
                CharacterToSell.sprite = ImageOfCharacterToSell[NumberItem];
                PriceToSell_Text.text = "$20";
                NameToSell_Text.text = "Girl";
                valueItem = 20;
                break;
            case 1:
                CharacterToSell.sprite = ImageOfCharacterToSell[NumberItem];
                PriceToSell_Text.text = "$30";
                NameToSell_Text.text = "Brown Skin";
                valueItem = 30;
                break;
            case 2:
                CharacterToSell.sprite = ImageOfCharacterToSell[NumberItem];
                PriceToSell_Text.text = "$50";
                NameToSell_Text.text = "Grey Skin";
                valueItem = 50;
                break;
            case 3:
                CharacterToSell.sprite = ImageOfCharacterToSell[NumberItem];
                PriceToSell_Text.text = "$80";
                NameToSell_Text.text = "Knight";
                valueItem = 80;
                break;
        }
    }

    /// <summary>
    /// Update the inventory and the store.
    /// </summary>
    public void SellItem()
    {
        switch (valueItem)
        {
            case 20:
                if(CustomizableCharacter.skinNr == 1)
                {
                    CustomizableCharacter.skinNr = 0;
                    PlayerImage.sprite = ImageOfCharacterToSell[4];
                    NameSkin.text = "Naked";
                }
                ItemsInInvetary[0].SetActive(false);
                InventoryToSell[0].SetActive(false);
                PlayerImageToSell.SetActive(false);
                StockInShop[0].SetActive(true); //Item de tienda
                OutOfStock[0].SetActive(false); //Anuncio de stock
                Text_Sold.SetActive(true);
                StartCoroutine(Timer());
                break;
            case 30:
                if (CustomizableCharacter.skinNr == 2)
                {
                    CustomizableCharacter.skinNr = 0;
                    PlayerImage.sprite = ImageOfCharacterToSell[4];
                    NameSkin.text = "Naked";
                }
                ItemsInInvetary[1].SetActive(false);
                InventoryToSell[1].SetActive(false);
                PlayerImageToSell.SetActive(false);
                StockInShop[1].SetActive(true); //Item de tienda
                OutOfStock[1].SetActive(false); //Anuncio de stock
                Text_Sold.SetActive(true);
                StartCoroutine(Timer());
                break;
            case 50:
                if (CustomizableCharacter.skinNr == 3)
                {
                    CustomizableCharacter.skinNr = 0;
                    PlayerImage.sprite = ImageOfCharacterToSell[4];
                    NameSkin.text = "Naked";
                }
                ItemsInInvetary[2].SetActive(false);
                InventoryToSell[2].SetActive(false);
                PlayerImageToSell.SetActive(false);
                StockInShop[2].SetActive(true); //Item de tienda
                OutOfStock[2].SetActive(false); //Anuncio de stock
                Text_Sold.SetActive(true);
                StartCoroutine(Timer());
                break;
            case 80:
                if (CustomizableCharacter.skinNr == 4)
                {
                    CustomizableCharacter.skinNr = 0;
                    PlayerImage.sprite = ImageOfCharacterToSell[4];
                    NameSkin.text = "Naked";
                }
                ItemsInInvetary[3].SetActive(false);
                InventoryToSell[3].SetActive(false);
                PlayerImageToSell.SetActive(false);
                StockInShop[3].SetActive(true); //Item de tienda
                OutOfStock[3].SetActive(false); //Anuncio de stock
                Text_Sold.SetActive(true);
                StartCoroutine(Timer());
                break;
        }
        Coins += valueItem;
        CoinText.text = Coins.ToString();
    }
    #endregion

    #region Coroutines
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        ShowItem.SetActive(false);
        Text_Sold.SetActive(false);
    }
    IEnumerator Timer(float t)
    {
        WarningNoMoney.SetActive(true);
        yield return new WaitForSeconds(t);
        WarningNoMoney.SetActive(false);
    }
    #endregion
}
