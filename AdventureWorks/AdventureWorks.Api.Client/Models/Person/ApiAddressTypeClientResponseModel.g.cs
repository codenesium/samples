using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiAddressTypeClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int addressTypeID,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.AddressTypeID = addressTypeID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public int AddressTypeID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>51362f3db500f1a24c4a9d4a381da1e7</Hash>
</Codenesium>*/