using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiUserServerResponseModel : AbstractApiServerResponseModel
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
		}

		[Required]
		[JsonProperty]
		public string BioImgUrl { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? Birthday { get; private set; }

		[Required]
		[JsonProperty]
		public string ContentDescription { get; private set; }

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public string FullName { get; private set; }

		[Required]
		[JsonProperty]
		public string HeaderImgUrl { get; private set; }

		[Required]
		[JsonProperty]
		public string Interest { get; private set; }

		[JsonProperty]
		public int LocationLocationId { get; private set; }

		[JsonProperty]
		public string LocationLocationIdEntity { get; private set; } = RouteConstants.Locations;

		[JsonProperty]
		public ApiLocationServerResponseModel LocationLocationIdNavigation { get; private set; }

		public void SetLocationLocationIdNavigation(ApiLocationServerResponseModel value)
		{
			this.LocationLocationIdNavigation = value;
		}

		[JsonProperty]
		public string Password { get; private set; }

		[Required]
		[JsonProperty]
		public string PhoneNumber { get; private set; }

		[JsonProperty]
		public string Privacy { get; private set; }

		[JsonProperty]
		public int UserId { get; private set; }

		[JsonProperty]
		public string Username { get; private set; }

		[Required]
		[JsonProperty]
		public string Website { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1e13a7f53c515d5fd0248230e1cd1611</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/