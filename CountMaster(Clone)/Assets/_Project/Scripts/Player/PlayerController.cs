using System;
using Modifiers;
using UnityEngine;

namespace Project
{
    public class PlayerController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Modifier"))
            {
                var modifier = other.GetComponent<ModifierBase>();
                if (modifier)
                {
                    modifier.Modify(this);
                }
            }
        }

    }
}