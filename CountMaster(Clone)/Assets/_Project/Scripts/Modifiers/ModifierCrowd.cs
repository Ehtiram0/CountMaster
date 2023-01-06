using System;
using Project;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modifiers
{
    public class ModifierCrowd : ModifierBase
    {
        [SerializeField] private  TextMeshPro ab;
        [SerializeField] private ModifierView modifierView;
         public int crowdModifyAmount;
        private bool _isPositive;

        private void Start()
        {
            crowdModifyAmount = int.Parse(ab.text);
            _isPositive = crowdModifyAmount > 0;
            modifierView.SetVisuals(_isPositive, crowdModifyAmount);
        }


        public override void Modify(PlayerController playerController)
        {
            var playerCrowd = playerController.GetComponent<PlayerCrowd>();
            for (int i = 0; i < Mathf.Abs(crowdModifyAmount); i++)
            {
                if(_isPositive) playerCrowd.Addplayerr();
                else playerCrowd.Removeplayerr();
            }
        }
    }
}