using System.Collections;
using System;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
   //funcion para crear usuario
   public void CreateUser( string userName, string email, string password, Action<Response> response)
   {
        StartCoroutine(CO_CreateUser(userName , email , password , response) );

   }

   private IEnumerator CO_CreateUser(string userName, string email, string password, Action<Response> response){
    WWWForm form = new WWWForm();
    form.AddField("userName",userName);
    form.AddField("email",email);
    form.AddField("password",password);

    WWW w = new WWW("http://localhost/mathgame/createUser.php",form);

    yield return w;

    response(JsonUtility.FromJson<Response>(w.text));

   }

   [Serializable]
   public class Response{
     public bool done = false;
     public string messagge ="";

   }
}
