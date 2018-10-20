using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiBusinessEntityAddressRequestModel : AbstractApiRequestModel
	{
		public ApiBusinessEntityAddressRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int addressID,
			int addressTypeID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.AddressID = addressID;
			this.AddressTypeID = addressTypeID;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[Required]
		[JsonProperty]
		public int AddressID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int AddressTypeID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>e852f39c6bb1a213cd911e895273f004</Hash>
</Codenesium>*/