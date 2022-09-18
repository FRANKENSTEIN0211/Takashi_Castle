using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object.Synchronizing;
using TMPro;

public class PlayerHealthGuide : MonoBehaviour
{
    [SyncVar] public int health=10;
    private TextMeshProUGUI healthText;
    
}
