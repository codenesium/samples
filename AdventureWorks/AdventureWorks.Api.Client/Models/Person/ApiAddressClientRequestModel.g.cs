using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiAddressClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiAddressClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string addressLine1,
			string addressLine2,
			string city,
			DateTime modifiedDate,
			string postalCode,
			Guid rowguid,
			int stateProvinceID)
		{
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.ModifiedDate = modifiedDate;
			this.PostalCode = postalCode;
			this.Rowguid = rowguid;
			this.StateProvinceID = stateProvinceID;
		}

		[JsonProperty]
		public string AddressLine1 { get; private set; } = default(string);

		[JsonProperty]
		public string AddressLine2 { get; private set; } = default(string);

		[JsonProperty]
		public string City { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string PostalCode { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public int StateProvinceID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>32f1b9fb61c214cd5b4750f80d9c5e92</Hash>
</Codenesium>*/