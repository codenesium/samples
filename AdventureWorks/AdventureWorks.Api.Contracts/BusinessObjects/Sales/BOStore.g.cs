using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOStore: AbstractBusinessObject
	{
		public BOStore() : base()
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

		public int BusinessEntityID { get; private set; }
		public string Demographics { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public Guid Rowguid { get; private set; }
		public Nullable<int> SalesPersonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>432a8d6484bba367d195ae12ddbc48e2</Hash>
</Codenesium>*/