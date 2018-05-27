using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSalesTerritoryHistory: AbstractDTO
	{
		public DTOSalesTerritoryHistory() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          Nullable<DateTime> endDate,
		                          DateTime modifiedDate,
		                          Guid rowguid,
		                          DateTime startDate,
		                          int territoryID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.EndDate = endDate.ToNullableDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.StartDate = startDate.ToDateTime();
			this.TerritoryID = territoryID.ToInt();
		}

		public int BusinessEntityID { get; set; }
		public Nullable<DateTime> EndDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime StartDate { get; set; }
		public int TerritoryID { get; set; }
	}
}

/*<Codenesium>
    <Hash>c98d2d8c488a3b886464ccb7c923b319</Hash>
</Codenesium>*/