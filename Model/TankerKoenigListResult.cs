using System;

namespace Ionos.Model
{
    public class TankerKoenigListResult
    {
        public Station[] Stations { get; set; }
    }

    public class Station
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Street { get; set; }
        public decimal? E5 { get; set; }
        public decimal? E10 { get; set; }
        public decimal? Diesel { get; set; }
    }
}