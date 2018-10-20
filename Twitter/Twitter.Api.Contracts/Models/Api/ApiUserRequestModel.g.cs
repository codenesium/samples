using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiUserRequestModel : AbstractApiRequestModel
	{
		public ApiUserRequestModel()
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
		public DateTime? Birthday { get; private set; } = default(DateTime);

		[JsonProperty]
		public string ContentDescription { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string FullName { get; private set; } = default(string);

		[JsonProperty]
		public string HeaderImgUrl { get; private set; } = default(string);

		[JsonProperty]
		public string Interest { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int LocationLocationId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[JsonProperty]
		public string PhoneNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Privacy { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Username { get; private set; } = default(string);

		[JsonProperty]
		public string Website { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>7efa3fefa2b58297e3dfd745c80da87d</Hash>
</Codenesium>*/