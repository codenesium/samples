using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOAddressType: AbstractDTO
	{
		public DTOAddressType() : base()
		{}

		public void SetProperties(int addressTypeID,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid)
		{
			this.AddressTypeID = addressTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
		}

		public int AddressTypeID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>0100533fc2c38af2f86645c2575237d6</Hash>
</Codenesium>*/