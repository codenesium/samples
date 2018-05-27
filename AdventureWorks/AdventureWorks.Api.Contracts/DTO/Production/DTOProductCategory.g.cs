using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductCategory: AbstractDTO
	{
		public DTOProductCategory() : base()
		{}

		public void SetProperties(int productCategoryID,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductCategoryID = productCategoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int ProductCategoryID { get; set; }
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>a1d965d8bf14e0e9d8d2e4c2adf05c7d</Hash>
</Codenesium>*/