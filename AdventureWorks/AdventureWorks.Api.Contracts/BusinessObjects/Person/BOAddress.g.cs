using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOAddress: AbstractBusinessObject
	{
		public BOAddress() : base()
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

		public int AddressID { get; private set; }
		public string AddressLine1 { get; private set; }
		public string AddressLine2 { get; private set; }
		public string City { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string PostalCode { get; private set; }
		public Guid Rowguid { get; private set; }
		public int StateProvinceID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5afb6658f276f90395d9fad33f8c1428</Hash>
</Codenesium>*/