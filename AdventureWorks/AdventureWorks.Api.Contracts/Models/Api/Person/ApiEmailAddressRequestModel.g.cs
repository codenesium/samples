using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiEmailAddressRequestModel : AbstractApiRequestModel
	{
		public ApiEmailAddressRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string emailAddress1,
			int emailAddressID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.EmailAddress1 = emailAddress1;
			this.EmailAddressID = emailAddressID;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public string EmailAddress1 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int EmailAddressID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>6440de21a1c7c1e3d97a3af420bda945</Hash>
</Codenesium>*/