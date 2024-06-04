using System.Collections.Generic;
using UnityEngine.UI;

namespace Deck
{
    public class PlayerHandController
    {
        readonly List<SlotCardController> _slotCardsControllers = new();

        public PlayerHandController(IReadOnlyPlayerHand playerHand, PlayerHandView view)
        {
            var slotsCard = playerHand.GetSlotsCard();

            for (var i = 0; i < slotsCard.Length; i++)
            {
                _slotCardsControllers.Add(new SlotCardController(slotsCard[i], view.GetCardView(i)));
            }
        }
    }
}