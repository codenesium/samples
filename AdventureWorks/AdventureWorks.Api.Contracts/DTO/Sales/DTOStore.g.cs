using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOStore: AbstractDTO
	{
		public DTOStore() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          string demographics,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid,
		                          Nullable<int> salesPersonID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Demographics = demographics;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.SalesPersonID = salesPersonID.ToNullableInt();
		}

		public int BusinessEntityID { get; set; }
		public string Demographics { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public Guid Rowguid { get; set; }
		public Nullable<int> SalesPersonID { get; set; }
	}
}

/*<Codenesium>
    <Hash>e4671d25d83454ac1ebed9610c39a2fb</Hash>
</Codenesium>*/