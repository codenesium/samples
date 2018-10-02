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
			string username)
		{
			this.Password = password;
			this.Username = username;
		}

		[Required]
		[JsonProperty]
		public string Password { get; private set; }

		[Required]
		[JsonProperty]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6e1e9119fdb13c61dab67c2c895cdbcf</Hash>
</Codenesium>*/