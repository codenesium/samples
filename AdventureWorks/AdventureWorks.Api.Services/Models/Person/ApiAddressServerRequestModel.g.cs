using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiAddressServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiAddressServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string AddressLine1 { get; private set; } = default(string);

		[JsonProperty]
		public string AddressLine2 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string City { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string PostalCode { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public int StateProvinceID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>fe4cfe6059413b8329ec248cde6d4ccc</Hash>
</Codenesium>*/