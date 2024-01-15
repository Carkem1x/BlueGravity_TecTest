using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableCharacter : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Determine which skin to use based on the variable's value.
    /// </summary>
    public static int skinNr;
    public Skins[] skins;
    SpriteRenderer spriteRenderer;
    #endregion

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(skinNr > skins.Length - 1)
        {
            skinNr = 0;
        }
        else if(skinNr < 0)
        {
            skinNr = skins.Length - 1;
        }
    }

    void LateUpdate()
    {
        SkinChoice();
    }

    /// <summary>
    /// With the name of the current skin, you can switch to a new one.
    /// </summary>
    void SkinChoice()
    {
        if (spriteRenderer.sprite.name.Contains("Civilian_Move"))
        {
            string spriteName = spriteRenderer.sprite.name;
            spriteName = spriteName.Replace("Civilian_Move_", "");
            int spriteNr = int.Parse(spriteName);

            spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];
        }
    }
}

[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}
