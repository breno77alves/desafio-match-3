using UnityEngine;
using System.Collections;

public class OpenLinks : MonoBehaviour
{
    public void OpenLink(string _link)
    {
        Application.OpenURL(_link);
    }
}