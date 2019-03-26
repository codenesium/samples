using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiAddressServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int addressID,
			string addressLine1,
			string addressLine2,
			string city,
			DateTime modifiedDate,
			string postalCode,
			Guid rowguid,
			int stateProvinceID)
		{
			this.AddressID = addressID;
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.ModifiedDate = modifiedDate;
			this.PostalCode = postalCode;
			this.Rowguid = rowguid;
			this.StateProvinceID = stateProvinceID;
		}

		[JsonProperty]
		public int AddressID { get; private set; }

		[JsonProperty]
		public string AddressLine1 { get; private set; }

		[Required]
		[JsonProperty]
		public string AddressLine2 { get; private set; }

		[JsonProperty]
		public string City { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string PostalCode { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int StateProvinceID { get; private set; }

		[JsonProperty]
		public string StateProvinceIDEntity { get; private set; } = RouteConstants.StateProvinces;

		[JsonProperty]
		public ApiStateProvinceServerResponseModel StateProvinceIDNavigation { get; private set; }

		public void SetStateProvinceIDNavigation(ApiStateProvinceServerResponseModel value)
		{
			this.StateProvinceIDNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>915a02e29d2ada8b61757a61ddfecbcd</Hash>
</Codenesium>*/