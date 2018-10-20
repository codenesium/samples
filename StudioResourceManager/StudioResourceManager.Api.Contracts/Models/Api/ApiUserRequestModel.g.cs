using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiUserRequestModel : AbstractApiRequestModel
	{
		public ApiUserRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string password,
			string username,
			bool isDeleted)
		{
			this.Password = password;
			this.Username = username;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Username { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>1d805be2085aa35edb06de153687d01b</Hash>
</Codenesium>*/