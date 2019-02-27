using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace TwitterNS.Api.Services
{
    public partial class ApiUserServerRequestModel : AbstractApiServerRequestModel
    {
        public ApiUserServerRequestModel() 
			: base()
        {
        }

						public virtual void SetProperties( 
			string bioImgUrl,
DateTime? birthday,
string contentDescription,
string email,
string fullName,
string headerImgUrl,
string interest,
int locationLocationId,
string password,
string phoneNumber,
string privacy,
string username,
string website)
        {
		this.BioImgUrl = bioImgUrl;
this.Birthday = birthday;
this.ContentDescription = contentDescription;
this.Email = email;
this.FullName = fullName;
this.HeaderImgUrl = headerImgUrl;
this.Interest = interest;
this.LocationLocationId = locationLocationId;
this.Password = password;
this.PhoneNumber = phoneNumber;
this.Privacy = privacy;
this.Username = username;
this.Website = website;

        }
		
		        [JsonProperty]
        public string BioImgUrl{ get; private set; } = default(string);

        [JsonProperty]
        public DateTime? Birthday{ get; private set; } = null;

        [JsonProperty]
        public string ContentDescription{ get; private set; } = default(string);

        [Required]
        [JsonProperty]
        public string Email{ get; private set; } = default(string);

        [Required]
        [JsonProperty]
        public string FullName{ get; private set; } = default(string);

        [JsonProperty]
        public string HeaderImgUrl{ get; private set; } = default(string);

        [JsonProperty]
        public string Interest{ get; private set; } = default(string);

        [Required]
        [JsonProperty]
        public int LocationLocationId{ get; private set; }

        [Required]
        [JsonProperty]
        public string Password{ get; private set; } = default(string);

        [JsonProperty]
        public string PhoneNumber{ get; private set; } = default(string);

        [Required]
        [JsonProperty]
        public string Privacy{ get; private set; } = default(string);

        [Required]
        [JsonProperty]
        public string Username{ get; private set; } = default(string);

        [JsonProperty]
        public string Website{ get; private set; } = default(string);

    }
}

/*<Codenesium>
    <Hash>d2a64fcbd47948d0e5c8d4e49969ba72</Hash>
</Codenesium>*/