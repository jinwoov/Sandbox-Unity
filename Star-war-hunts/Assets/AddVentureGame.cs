using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddVentureGame : MonoBehaviour
{
    [SerializeField] Text TextComponent;  // available in inspector

    // Start is called before the first frame update
    void Start()
    {
        TextComponent.text = "Its the mochi, underwater goachi";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
