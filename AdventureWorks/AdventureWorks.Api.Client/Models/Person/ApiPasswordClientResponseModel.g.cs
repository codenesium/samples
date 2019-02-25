using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiPasswordClientResponseModel : AbstractApiClientResponseModel
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

			this.BusinessEntityIDEntity = nameof(ApiResponse.People);
		}

		[JsonProperty]
		public ApiPersonClientResponseModel BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(ApiPersonClientResponseModel value)
		{
			this.BusinessEntityIDNavigation = value;
		}

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public string BusinessEntityIDEntity { get; set; }

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
    <Hash>3fda71c955f4bc0d9ea5b273a4160527</Hash>
</Codenesium>*/