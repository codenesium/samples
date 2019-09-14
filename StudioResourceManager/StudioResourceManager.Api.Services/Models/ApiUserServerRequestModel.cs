using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiUserServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiUserServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string password,
			string username)
		{
			this.Password = password;
			this.Username = username;
		}

		[Required]
		[JsonProperty]
		public string Password { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Username { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>8cc746a503d6bea4ba0da56c85343624</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/