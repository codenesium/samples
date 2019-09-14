using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiUserClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int userId,
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
			this.UserId = userId;
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

			this.LocationLocationIdEntity = nameof(ApiResponse.Locations);
		}

		[JsonProperty]
		public ApiLocationClientResponseModel LocationLocationIdNavigation { get; private set; }

		public void SetLocationLocationIdNavigation(ApiLocationClientResponseModel value)
		{
			this.LocationLocationIdNavigation = value;
		}

		[JsonProperty]
		public string BioImgUrl { get; private set; }

		[JsonProperty]
		public DateTime? Birthday { get; private set; }

		[JsonProperty]
		public string ContentDescription { get; private set; }

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public string FullName { get; private set; }

		[JsonProperty]
		public string HeaderImgUrl { get; private set; }

		[JsonProperty]
		public string Interest { get; private set; }

		[JsonProperty]
		public int LocationLocationId { get; private set; }

		[JsonProperty]
		public string LocationLocationIdEntity { get; set; }

		[JsonProperty]
		public string Password { get; private set; }

		[JsonProperty]
		public string PhoneNumber { get; private set; }

		[JsonProperty]
		public string Privacy { get; private set; }

		[JsonProperty]
		public int UserId { get; private set; }

		[JsonProperty]
		public string Username { get; private set; }

		[JsonProperty]
		public string Website { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c4776e34e953dd6825f26e26b5e66f36</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/