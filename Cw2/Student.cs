using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Cw2
{
    [Serializable]
    internal class Student
    {
        [XmlAttribute(AttributeName = "InnaNazwa")]
        [JsonPropertyName("StudentId")]
        public string StudentId { get; internal set; }

        [XmlAttribute(AttributeName = "InnaNazwa")]
        [JsonPropertyName("Imie")]
        public string Imie { get; internal set; }

        [XmlAttribute(AttributeName = "InnaNazwa")]
        [JsonPropertyName("Nazwisko")]
        public string Nazwisko { get; internal set; }

        [XmlAttribute(AttributeName = "InnaNazwa")]
        [JsonPropertyName("Birthdate")]
        public string Birthdate { get; internal set; }

        [XmlAttribute(AttributeName = "InnaNazwa")]
        [JsonPropertyName("Email")]
        public string Email { get; internal set; }

        [XmlAttribute(AttributeName = "InnaNazwa")]
        [JsonPropertyName("MothersName")]
        public string MothersName { get; internal set; }

        [XmlAttribute(AttributeName = "InnaNazwa")]
        [JsonPropertyName("FathersName")]
        public string FathersName { get; internal set; }
    }
}