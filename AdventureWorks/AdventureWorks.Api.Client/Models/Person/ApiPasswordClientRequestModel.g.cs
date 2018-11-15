using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiPasswordClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPasswordClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string passwordHash,
			string passwordSalt,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate;
			this.PasswordHash = passwordHash;
			this.PasswordSalt = passwordSalt;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string PasswordHash { get; private set; } = default(string);

		[JsonProperty]
		public string PasswordSalt { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>6cf9755dbda6f6968871e3482e4c7509</Hash>
</Codenesium>*/