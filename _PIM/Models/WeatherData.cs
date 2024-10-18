namespace _PIM.Models
{
    public class WeatherData
    {
        public MainData Main { get; set; }
        public WindData Wind { get; set; }

        public class MainData
        {
            public double Temp { get; set; } 
            public double Humidity { get; set; } 
        }

        public class WindData
        {
            public double Speed { get; set; }
        }
    }
}
