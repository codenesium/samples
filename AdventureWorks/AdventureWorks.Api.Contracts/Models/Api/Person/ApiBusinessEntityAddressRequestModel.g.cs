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
		public int AddressID { get; private set; }

		[Required]
		[JsonProperty]
		public int AddressTypeID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4defc048c64ad6a245aa9f6a83079f59</Hash>
</Codenesium>*/