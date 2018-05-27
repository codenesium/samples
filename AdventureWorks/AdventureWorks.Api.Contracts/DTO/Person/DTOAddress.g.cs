using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOAddress: AbstractDTO
	{
		public DTOAddress() : base()
		{}

		public void SetProperties(int addressID,
		                          string addressLine1,
		                          string addressLine2,
		                          string city,
		                          DateTime modifiedDate,
		                          string postalCode,
		                          Guid rowguid,
		                          int stateProvinceID)
		{
			this.AddressID = addressID.ToInt();
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PostalCode = postalCode;
			this.Rowguid = rowguid.ToGuid();
			this.StateProvinceID = stateProvinceID.ToInt();
		}

		public int AddressID { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string PostalCode { get; set; }
		public Guid Rowguid { get; set; }
		public int StateProvinceID { get; set; }
	}
}

/*<Codenesium>
    <Hash>e07120c883f1d9a541604a484767798f</Hash>
</Codenesium>*/