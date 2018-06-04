using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
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
    <Hash>a6b452d4d98233ebc35148fb13024431</Hash>
</Codenesium>*/