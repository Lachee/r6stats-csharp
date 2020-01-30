using Newtonsoft.Json;
using R6Stats.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R6Stats.Responses
{
    public class WeaponCategoryResponse : BaseResponse
    {
        [JsonProperty("categories")]
        public WeaponCategory[] Categories { get; private set; }
    }
}
