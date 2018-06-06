using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOSalesTerritoryHistory: AbstractBusinessObject
	{
		public BOSalesTerritoryHistory() : base()
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

		public int BusinessEntityID { get; private set; }
		public Nullable<DateTime> EndDate { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Guid Rowguid { get; private set; }
		public DateTime StartDate { get; private set; }
		public int TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4134e5d48b9e1725cf8fcf76f34e503d</Hash>
</Codenesium>*/