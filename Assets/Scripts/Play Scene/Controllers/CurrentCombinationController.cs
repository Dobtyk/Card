namespace Deck
{
    public class CurrentCombinationController
    {
        readonly CurrentCombinationView _view;
        public CurrentCombinationController(IReadOnlyCurrentCombination currentCombination, CurrentCombinationView view)
        {
            _view = view;

            currentCombination.CurrentCombinationNameChanged += OnCurrentCombinationChanged;
            currentCombination.CurrentCombinationChipsChanged += OnCurrentCombinationChipsChanged;
            currentCombination.CurrentCombinationFactorChanged += OnCurrentCombinationFactorChanged;

            view.NameCombination = currentCombination.Name;
            view.Chips = currentCombination.Chips.ToString();
            view.Factor = currentCombination.Factor.ToString();
        }

        private void OnCurrentCombinationFactorChanged(int factor)
        {
            _view.Factor = factor.ToString();
        }

        private void OnCurrentCombinationChipsChanged(int chips)
        {
            _view.Chips = chips.ToString();
        }

        void OnCurrentCombinationChanged(string name)
        {
            _view.NameCombination = name;
        }
    }
}