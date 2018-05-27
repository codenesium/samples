using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOBusinessEntityAddress: AbstractDTO
	{
		public DTOBusinessEntityAddress() : base()
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

		public int AddressID { get; set; }
		public int AddressTypeID { get; set; }
		public int BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>ebadb68b91987d353fca340a2f23c584</Hash>
</Codenesium>*/