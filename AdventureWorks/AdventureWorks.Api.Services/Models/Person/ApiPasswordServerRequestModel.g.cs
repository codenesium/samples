using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiPasswordServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPasswordServerRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string PasswordHash { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string PasswordSalt { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>befa2f2eae939af5056ca1554a94bb21</Hash>
</Codenesium>*/