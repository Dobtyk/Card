using System;
using UnityEngine;

namespace Deck
{
    [Serializable]
    public class LevelInfoData
    {
        public int NumberLevel;
        public int Points;
        public int ChanceLightBuff;
        public int ChanceMediumBuff;
        public int ChanceGreatBuff;
        public string Name;
        public Sprite Icon;
    }
}