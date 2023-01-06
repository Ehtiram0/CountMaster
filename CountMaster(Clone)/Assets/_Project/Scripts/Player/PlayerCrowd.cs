using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project
{
    public class PlayerCrowd : MonoBehaviour
    {
        [SerializeField] private int crowdSizeForDebug = 5;
        [SerializeField] private int startingCrowdSize = 1;

        [SerializeField] private Player playerrPrefab;
        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
        private List<Player> player = new List<Player>();
        public List<Player> playerrs => player;
        [ContextMenu("Set")]
        public void Debug_ResizeCrowd() => Set(crowdSizeForDebug);

        [SerializeField] private TMP_Text Count;

        private int _year;

        private void Start()
        {
            Set(startingCrowdSize);
            Count.text = player.Count.ToString();
        }
        public void Set(int amount)
        {
            if (player.Count == amount) return;
            var needToRemove = amount < player.Count;
            var needToAdd = amount > player.Count;
            while (amount != player.Count)
            {
                if(needToRemove) Removeplayerr();
                else if (needToAdd) Addplayerr();
            }
        }

        public bool CanAdd()
        {
            return player.Count + 1 <= spawnPoints.Count;
        }

        public bool CanRemove()
        {
            return player.Count - 2 >= 0;
        }
        public void Removeplayerr()
        {
            if (!CanRemove()) return;
            var lastplayerr = player[player.Count - 1];
            player.Remove(lastplayerr);
            Destroy(lastplayerr.gameObject);
        }

        public void Addplayerr()
        {
            if (!CanAdd()) return;
            var lastplayerrIndex = player.Count - 1;
            var position = spawnPoints[lastplayerrIndex + 1].position;
            var playerr = Instantiate(playerrPrefab, position, Quaternion.identity, transform);
            player.Add(playerr);
            Count.text = player.Count.ToString();
        }
    }
}