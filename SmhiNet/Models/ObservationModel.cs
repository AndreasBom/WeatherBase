using System;


namespace SmhiNet.Models
{
    /// <summary>
    /// Model for observations
    /// </summary>
    public class ObservationModel
    {
        private DateTime? _date;
        private string _parameterUnit;

        public DateTime? To { get; set; }
        public DateTime? From { get; set; }
        public string Ref { get; set; }

        public DateTime? Date
        {
            get
            {
                if (_date == null)
                {
                    return Convert.ToDateTime(Ref);
                }
                return _date;
            }
            set
            {
                _date = value;
            }
        }


        public float Value { get; set; }

        public string Quality { get; set; }

        public DateTime? Updated { get; set; }

        public int ParameterKey { get; set; }

        public string ParameterName { get; set; }

        public string ParameterSummary { get; set; }

        public string ParameterUnit
        {
            get
            {
                switch (_parameterUnit)
                {
                    case "degree celsius":
                        return  "grader";
                        
                    case "metre per second":
                        return  "m/s";
                        
                    case "degree true":
                        return  "grader";
                        
                }
                return null;
            }
            set
            {
                _parameterUnit = value;
            }
        }

        public string StationKey { get; set; }

        public string StationName { get; set; }

        public int StationHeight { get; set; }

        public string PeriodKey { get; set; }

        public DateTime? PeriodFrom { get; set; }

        public DateTime? PeriodTo { get; set; }

        public string PeriodSummary { get; set; }

        public string PeriodSampling { get; set; }

        public DateTime? PositionFrom { get; set; }

        public DateTime? PositionTo { get; set; }

        public int PositionHeight { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }   
    }

}
