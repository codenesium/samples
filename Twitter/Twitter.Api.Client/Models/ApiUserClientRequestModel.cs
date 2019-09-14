using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiUserClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiUserClientRequestModel()
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
		public string BioImgUrl { get; private set; } = default(string);

		[JsonProperty]
		public DateTime? Birthday { get; private set; } = null;

		[JsonProperty]
		public string ContentDescription { get; private set; } = default(string);

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public string FullName { get; private set; } = default(string);

		[JsonProperty]
		public string HeaderImgUrl { get; private set; } = default(string);

		[JsonProperty]
		public string Interest { get; private set; } = default(string);

		[JsonProperty]
		public int LocationLocationId { get; private set; }

		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[JsonProperty]
		public string PhoneNumber { get; private set; } = default(string);

		[JsonProperty]
		public string Privacy { get; private set; } = default(string);

		[JsonProperty]
		public string Username { get; private set; } = default(string);

		[JsonProperty]
		public string Website { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>edf9a2e85de1e7127c5a9964f4b553c6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/