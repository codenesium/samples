using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiAddressClientResponseModel : AbstractApiClientResponseModel
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

			this.StateProvinceIDEntity = nameof(ApiResponse.StateProvinces);
		}

		[JsonProperty]
		public ApiStateProvinceClientResponseModel StateProvinceIDNavigation { get; private set; }

		public void SetStateProvinceIDNavigation(ApiStateProvinceClientResponseModel value)
		{
			this.StateProvinceIDNavigation = value;
		}

		[JsonProperty]
		public int AddressID { get; private set; }

		[JsonProperty]
		public string AddressLine1 { get; private set; }

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
		public string StateProvinceIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>fcac5ba8956300a3463ea451990b9d17</Hash>
</Codenesium>*/