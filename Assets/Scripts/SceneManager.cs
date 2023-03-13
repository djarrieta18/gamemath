
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    //hacemos referencia a los campos del formulario
    [SerializeField] private InputField  m_userNameInput    = null;
    [SerializeField] private InputField  m_emailInput       = null;
    [SerializeField] private InputField  m_password         = null;
    [SerializeField] private InputField  m_confirmpassword  = null;
    [SerializeField] private Text  m_errorText              = null;

    //hacemos referencia a los objetos que tenemos en la vista para asignarles su estado
    [SerializeField] private GameObject m_registerUI        = null;
    [SerializeField] private GameObject m_loginUI           = null;
    [SerializeField] private GameObject m_rolUI             = null;

    private NetworkManager m_networkManager = null ; //Creamos la intancia para usar luego nuestro codigo para crear usuario

    private void Awake() 
    {
        
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
        
    }
    public void  submitLogin()
   {
        if (m_userNameInput.text == "" || m_emailInput.text == "" || m_password.text == "" || m_confirmpassword.text == "" )
        {
            m_errorText.text ="Porfavor llene todos los campos ";
            return;

        }
        if (m_password.text == m_confirmpassword.text)
        {
            m_errorText.text = "Validando";
            m_networkManager.CreateUser(m_userNameInput.text , m_emailInput.text , m_password.text , (NetworkManager.Response response)=> { m_errorText.text = response.messagge;} );
        }
        else{
            m_errorText.text ="Contraseñas no concuerdan, verifica los dos campos ";


        }

   }
    public void ShowLogin()
    {

            m_registerUI.SetActive(false);
            m_loginUI.SetActive(true);
            m_rolUI.SetActive(false);

    }

    public void ShowRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);
        m_rolUI.SetActive(false);
        
    }

    public void ShowRol()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(false);
        m_rolUI.SetActive(true);
    }
}
