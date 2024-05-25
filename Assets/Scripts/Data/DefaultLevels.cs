using System;
using System.Collections.Generic;

namespace Deck
{
    [Serializable]
    static public class DefaultLevels
    {
        static public List<LevelInfoData> Levels = new List<LevelInfoData>
        {
            new LevelInfoData {NumberLevel = 1, Points = 200, ChanceLightBuff = 0, ChanceMediumBuff = 0, ChanceGreatBuff = 0, Name = "Фе"},
            new LevelInfoData {NumberLevel = 2, Points = 200, ChanceLightBuff = 0, ChanceMediumBuff = 0, ChanceGreatBuff = 0, Name = "Каун"},
            new LevelInfoData {NumberLevel = 3, Points = 400, ChanceLightBuff = 65, ChanceMediumBuff = 30, ChanceGreatBuff = 5, Name = "Турс"},
            new LevelInfoData {NumberLevel = 4, Points = 400, ChanceLightBuff = 65, ChanceMediumBuff = 30, ChanceGreatBuff = 5, Name = "Рейд"},
            new LevelInfoData {NumberLevel = 5, Points = 600, ChanceLightBuff = 40, ChanceMediumBuff = 50, ChanceGreatBuff = 10, Name = "Хагалль"},
            new LevelInfoData {NumberLevel = 6, Points = 600, ChanceLightBuff = 40, ChanceMediumBuff = 50, ChanceGreatBuff = 10, Name = "Наудр"},
            new LevelInfoData {NumberLevel = 7, Points = 800, ChanceLightBuff = 30, ChanceMediumBuff = 50, ChanceGreatBuff = 20, Name = "Бьяркан"},
            new LevelInfoData {NumberLevel = 8, Points = 1000, ChanceLightBuff = 0, ChanceMediumBuff = 0, ChanceGreatBuff = 0, Name = "Тюр"},
        };
    }
}