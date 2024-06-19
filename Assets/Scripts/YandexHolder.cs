using Deck;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Leaderboard;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

static public class Yandexholder
{
    static public List<Effect> KnowBuffs;
    static public List<Effect> KnowDebuffs;
    static public List<LeaderboardEntry> Players;
    static public int ScorePlayer;

    static public void LoadInformation()
    {
        Bridge.leaderboard.GetScore(OnGetScoreCompleted, new GetScoreYandexOptions("MaximumPointsss"));
        Bridge.leaderboard.GetEntries(OnGetEntriesComplete, new GetEntriesYandexOptions("MaximumPointsss", true, 6, 0));
        Bridge.storage.Get("buffs", OnStorageGetCompletedBuff);
        Bridge.storage.Get("debuffs", OnStorageGetCompletedDebuff);
    }

    static public void SaveBuffs(List<Effect> list)
    {
        var combinedList = list.Concat(KnowBuffs).Distinct().OrderBy(b => b.Difficulty).ToList();
        KnowBuffs = combinedList;
        var data = string.Join(" ", combinedList.Select(b => b.Id.ToString()).ToList());
        Bridge.storage.Set("buffs", data, OnStorageSetCompleted);
    }

    static public void SaveScore()
    {
        if (ScorePlayer < DataHolder.TotalNumberPointsScored)
        {
            Bridge.leaderboard.SetScore(new SetScoreYandexOptions(DataHolder.TotalNumberPointsScored, "MaximumPointsss"));
        }
    }

    static public void SaveDebuffs(List<Effect> list)
    {
        var combinedList = list.Concat(KnowDebuffs).Distinct().ToList();
        KnowDebuffs = combinedList;
        var data = string.Join(" ", combinedList.Select(b => b.Id.ToString()).ToList());
        Bridge.storage.Set("debuffs", data, OnStorageSetCompleted);

    }

    static void OnStorageGetCompletedBuff(bool success, string data)
    {
        if (success)
        {
            if (data != null)
            {
                var _knowBuffsNumber = Array.ConvertAll(data.Split(' '), s => int.Parse(s));
                KnowBuffs = new Effects().Buffs.Where(o => _knowBuffsNumber.Contains(o.Id)).OrderBy(b => b.Difficulty).ToList();
            }
            else
            {
                KnowBuffs = new List<Effect>();
            }
        }
        else
        {
            // Ошибка, что-то пошло не так
        }
    }

    static void OnStorageGetCompletedDebuff(bool success, string data)
    {
        if (success)
        {
            if (data != null)
            {
                var _knowDebuffsNumber = Array.ConvertAll(data.Split(' '), s => int.Parse(s));
                KnowDebuffs = new Effects().Debuffs.Where(o => _knowDebuffsNumber.Contains(o.Id)).ToList();
            }
            else
            {
                KnowDebuffs = new List<Effect>();
            }
        }
        else
        {
            // Ошибка, что-то пошло не так
        }
    }

    static void OnStorageSetCompleted(bool success)
    {
        Debug.Log($"OnStorageSetCompleted, success: {success}");
    }

    static void OnGetEntriesComplete(bool success, List<LeaderboardEntry> entries)
    {
        if (success)
        {
            Players = entries;
        }
    }

    static void OnGetScoreCompleted(bool success, int score)
    {
        if (success)
        {
            ScorePlayer = score;
        }
        else
        {
            // Что-то пошло не так
        }
    }
}
