using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOBusinessEntity: AbstractBusinessObject
	{
		public BOBusinessEntity() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          DateTime modifiedDate,
		                          Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		public int BusinessEntityID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>75ae332e1937900b2a2008a2d684780a</Hash>
</Codenesium>*/