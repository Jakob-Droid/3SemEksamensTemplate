using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLibrary
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        private string _regNo;

        public string Name { get; set; }
        public string RegNo {
            get { { return _regNo; } }
            set
            {
                if (value.Length == 8)
                {
                    _regNo = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(null, "A RegNo is always 8 letters");
                }
            }
        }

        public string Color { get; set;}

        public override string ToString()
        {
            return $"{Name}, {RegNo}, {Color}";
        }
        public Car()
        {
            
        }
    }
}
