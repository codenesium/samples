using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiUserResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string password,
			string username,
			bool isDeleted)
		{
			this.Id = id;
			this.Password = password;
			this.Username = username;
			this.IsDeleted = isDeleted;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Password { get; private set; }

		[JsonProperty]
		public string Username { get; private set; }

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d6b5263a1409c6648677f8e0eb10676c</Hash>
</Codenesium>*/