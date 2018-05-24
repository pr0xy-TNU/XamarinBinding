using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace McuRegister.Models
{
    public class TrailerModel
    {
        //[JsonProperty(PropertyName = "trailer_id")]
        public string Id { get; set; }

      //  [JsonProperty(PropertyName = "mcu_serial")]
        public string McuSerialNumber { get; set; }

     //   [JsonProperty(PropertyName = "landmark_id")]
        public string LandmarkSerialNumber { get; set; }

      //  [JsonProperty(PropertyName ="company")]
        public string Company { get; set; }
    }
}
