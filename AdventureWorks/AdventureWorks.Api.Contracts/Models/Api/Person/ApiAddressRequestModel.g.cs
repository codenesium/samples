using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiAddressRequestModel : AbstractApiRequestModel
	{
		public ApiAddressRequestModel()
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
		public string AddressLine1 { get; private set; }

		[JsonProperty]
		public string AddressLine2 { get; private set; }

		[Required]
		[JsonProperty]
		public string City { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public string PostalCode { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public int StateProvinceID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>915833713bc4ede05fa78931c819243e</Hash>
</Codenesium>*/