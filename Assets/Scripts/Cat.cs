using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEditor.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Cat : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public float shakeIntensity;

    public GameObject Pastel;
    public GameObject Chile;
    public GameObject Sushi;

    public float timer;

    public float fillSpeed = 0.1f; // Velocidad de llenado por segundo
    public Image image; // Referencia a la imagen que quieres llenar
    private float currentFill = 1f; // Valor actual de llenado

    public Transform m_player;

    public Volume volume;
    private Vignette vignette;
    public Color blackColor = Color.black; // Color para cuando colorIndex sea 0
    public Color pinkColor = Color.magenta; // Color para cuando colorIndex sea 1

    public GameObject bueno;
    public GameObject malo;


    private void Start() {
        StartCoroutine(Timer());
        //volume = GetComponent<Volume>();

    }
    private void Update() {

        if (volume.profile.TryGet(out Vignette _vignette)) {
            vignette = _vignette;

            // Calcular el color intermedio usando la función Lerp
            Color interpolatedColor = Color.Lerp(blackColor, pinkColor, currentFill);

            // Asignar el color intermedio al Vignette
            vignette.color.value = interpolatedColor;
        }

        currentFill -= fillSpeed * Time.deltaTime;

        // Limita el valor de llenado entre 0 y 1
        currentFill = Mathf.Clamp01(currentFill);

        // Aplica el valor de llenado a la imagen
        image.fillAmount = currentFill;

        // Verifica si el llenado ha alcanzado 1
        if (currentFill <= 0) {
            SceneManager.LoadScene("Menu");
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
                StartCoroutine(Cambio(bueno));
                //timer = 0;
            }
            else if (Player.isPastel && Pastel.activeSelf) {
                print("Es pastel y te salvaste");
                collision.transform.GetChild(1).gameObject.SetActive(false);
                Player.isPastel = false;
                Player.isWithObj = false;
                currentFill += 0.5f;
                StartCoroutine(Cambio(bueno));
                //timer = 0;
            } else if (Player.isSushi && Sushi.activeSelf) {
                print("Es sushi y te salvaste");
                collision.transform.GetChild(2).gameObject.SetActive(false);
                Player.isSushi = false;
                Player.isWithObj = false;
                currentFill += 0.5f;
                StartCoroutine(Cambio(bueno));
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
                StartCoroutine(Cambio(malo));
                StartCoroutine(ShakeCam());
                //timer = 0;
            }
        }
    }

    IEnumerator Cambio(GameObject g) {
        g.SetActive(true);
        yield return new WaitForSeconds(1);
        g.SetActive(false);
    }

    IEnumerator ShakeCam() {
        CinemachineBasicMultiChannelPerlin _cbmcp = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = shakeIntensity;
        yield return new WaitForSeconds(0.5f);
        _cbmcp.m_AmplitudeGain = 0;
    }
}
