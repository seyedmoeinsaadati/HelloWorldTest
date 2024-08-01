namespace FlipFlop
{
    [System.Serializable]
    public class MatchCardGuess
    {
        private bool _active = false;
        private Card _card = null;

        public bool Active => _active;

        public Card Card => _card;

        public void Set(Card card)
        {
            _active = true;
            _card = card;
            _card.FlipUp();
        }

        public void Reset()
        {
            if (_active)
                _card.FlipBack();

            _active = false;
            _card = null;
        }

        public void Clear()
        {
        }

        public bool Equals(MatchCardGuess guess)
        {
            return _card.Id == guess._card.Id;
        }
    }
}