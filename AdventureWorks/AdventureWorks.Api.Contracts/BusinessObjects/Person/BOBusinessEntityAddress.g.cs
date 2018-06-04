using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOBusinessEntityAddress: AbstractBusinessObject
	{
		public BOBusinessEntityAddress() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          int addressID,
		                          int addressTypeID,
		                          DateTime modifiedDate,
		                          Guid rowguid)
		{
			this.AddressID = addressID.ToInt();
			this.AddressTypeID = addressTypeID.ToInt();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		public int AddressID { get; private set; }
		public int AddressTypeID { get; private set; }
		public int BusinessEntityID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9800cbef3804f63819ee6b863dfc77dd</Hash>
</Codenesium>*/