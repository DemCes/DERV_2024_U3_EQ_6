using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ManagerUI_adv : MonoBehaviour
{

    private ManagerUI_adv instance;

    [SerializeField] GameObject usuario;

    TextMeshProUGUI nombre_usuario;

    string usu;

    int id_active_scene;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        id_active_scene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
     void Update()
    {
        int id_active_scene = SceneManager.GetActiveScene().buildIndex; //3, 4, 5
        if (id_active_scene != 3)
        {
            //nombre_usuario = usuario.GetComponent<TextMeshProUGUI>();
             PlayerPrefs.SetString("usu", ""); //almacena el string que ingreso el usuario
        }
    }

    public void cambiarEscena(int index_new)
    {
        if (id_active_scene == 3)
        {
            nombre_usuario = usuario.GetComponent<TextMeshProUGUI>();
            usu = nombre_usuario.text; //almacena el string que ingreso el usuario
            PlayerPrefs.SetString("usu", usu);

        }

        SceneManager.LoadScene(index_new);
    }

}

