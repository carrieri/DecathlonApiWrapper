using DecathlonApiWrapper.Builder;

namespace DecathlonApiWrapper
{
    public class Decathlon
    {
        private Places Places;

        public Decathlon()
        {
            Places = new Places();
        }

        public Places SearchForPlaces()
        {
            return Places;
        }
    }
}