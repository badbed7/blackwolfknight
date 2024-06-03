using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public void ToJohnLemon()
    {
        SceneManager.LoadScene("Main");
    }

    public void toPractical()
    {
        SceneManager.LoadScene("Streets");
    }

}
