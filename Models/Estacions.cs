using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leafletDemo.Models
{
    [Table("archive")]
    public class Estacions
    {

        [Required]
        [Key]
        public int? dateTime { get; set; }

        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime dataHuma { get; set; }

        public int? usUnits { get; set; }
        public int? arcInt { get; set; }
        public int? barometer { get; set; }
        public int? pressure { get; set; }
        public int? altimeter { get; set; }
        public int? inTemp { get; set; }
        public int? outTemp { get; set; }
        public int? inHumidity { get; set; }
        public int? outHumidity { get; set; }
        public int? windSpeed { get; set; } 
        public int? windDir { get; set; }
        public int? windGust { get; set; }
        public int? windGustDir { get; set; }
        public int? rainRate { get; set; }
        public int? rain { get; set; }
        public int? dewpoint { get; set; }
        public int? windchill { get; set; }
        public int? heatindex { get; set; }

    }
}