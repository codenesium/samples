using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiPasswordServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			string passwordHash,
			string passwordSalt,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public string BusinessEntityIDEntity { get; private set; } = RouteConstants.People;

		[JsonProperty]
		public ApiPersonServerResponseModel BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(ApiPersonServerResponseModel value)
		{
			this.BusinessEntityIDNavigation = value;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string PasswordHash { get; private set; }

		[JsonProperty]
		public string PasswordSalt { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d95f2d1129043cda51cc9cd2151f8cff</Hash>
</Codenesium>*/