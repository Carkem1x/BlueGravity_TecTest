using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{

    public GameObject Pastel;
    public GameObject Chile;
    public GameObject Sushi;

    public float timer;
    NavMeshAgent agent;

    public float fillSpeed = 0.1f; // Velocidad de llenado por segundo
    public Image image; // Referencia a la imagen que quieres llenar
    private float currentFill = 1f; // Valor actual de llenado

    public Transform m_player;

    private void Start() {
        StartCoroutine(Timer());
        agent = GetComponent<NavMeshAgent>();


    }
    private void Update() {
        agent.SetDestination(m_player.position);

        currentFill -= fillSpeed * Time.deltaTime;

        // Limita el valor de llenado entre 0 y 1
        currentFill = Mathf.Clamp01(currentFill);

        // Aplica el valor de llenado a la imagen
        image.fillAmount = currentFill;

        // Verifica si el llenado ha alcanzado 1
        if (currentFill <= 0) {
            Debug.Log("¡Se acabo!");
            // Puedes añadir aquí cualquier otra acción que quieras realizar cuando el llenado esté completo
        }
    }

    IEnumerator Timer() {

        int randomNumber = Random.Range(1, 4);
        //print("El numero fue: " +  randomNumber);
        switch (randomNumber) {
            case 1:
                Pastel.SetActive(true);
                break;
            case 2:
                Chile.SetActive(true);
                break;
            case 3:
                Sushi.SetActive(true);
                break;
        }

        
        yield return new WaitForSeconds(timer);
        Pastel.SetActive(false);
        Chile.SetActive(false);
        Sushi.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Timer());
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && Player.isWithObj) {
            if(Player.isChile && Chile.activeSelf) {
                print("Es chile y te salvaste");
                collision.transform.GetChild(0).gameObject.SetActive(false);
                Player.isChile = false;
                Player.isWithObj = false;
                currentFill += 0.5f;
                //timer = 0;
            }
            else if (Player.isPastel && Pastel.activeSelf) {
                print("Es pastel y te salvaste");
                collision.transform.GetChild(1).gameObject.SetActive(false);
                Player.isPastel = false;
                Player.isWithObj = false;
                currentFill += 0.5f;
                //timer = 0;
            } else if (Player.isSushi && Sushi.activeSelf) {
                print("Es sushi y te salvaste");
                collision.transform.GetChild(2).gameObject.SetActive(false);
                Player.isSushi = false;
                Player.isWithObj = false;
                currentFill += 0.5f;
                //timer = 0;
            } else {
                print("Ya valio");
                collision.transform.GetChild(0).gameObject.SetActive(false);
                collision.transform.GetChild(1).gameObject.SetActive(false);
                collision.transform.GetChild(2).gameObject.SetActive(false);
                Player.isSushi = false;
                Player.isPastel = false;
                Player.isChile = false;
                Player.isWithObj = false;
                //timer = 0;
            }
        }
    }

}
