using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableManager : MonoBehaviour {

    public float fillSpeed = 0.2f; // Velocidad de llenado por segundo
    public Image image; // Referencia a la imagen que quieres llenar

    private float currentFill = 1f; // Valor actual de llenado
    public Platillo m_platillo;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        currentFill += fillSpeed * Time.deltaTime;

        // Limita el valor de llenado entre 0 y 1
        currentFill = Mathf.Clamp01(currentFill);

        // Aplica el valor de llenado a la imagen
        image.fillAmount = currentFill;

        // Verifica si el llenado ha alcanzado 1
        if (currentFill >= 1f) {
            //Debug.Log("¡Llenado completo!");
            // Puedes añadir aquí cualquier otra acción que quieras realizar cuando el llenado esté completo
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player") && currentFill >= 1f) {
            //print("se logro");
            currentFill = 0;
            Player.isWithObj = true;
            switch (m_platillo) {
                case Platillo.chile:
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    Player.isChile = true;
                    break;
                case Platillo.pastel:
                    collision.transform.GetChild(1).gameObject.SetActive(true);
                    Player.isPastel = true;
                    break;
                case Platillo.Shushi:
                    collision.transform.GetChild(2).gameObject.SetActive(true);
                    Player.isSushi = true;
                    break;
            }

        }
    }
}

public enum Platillo {
    chile,
    pastel,
    Shushi
}