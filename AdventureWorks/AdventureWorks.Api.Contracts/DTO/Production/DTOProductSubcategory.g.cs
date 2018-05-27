using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductSubcategory: AbstractDTO
	{
		public DTOProductSubcategory() : base()
		{}

		public void SetProperties(int productSubcategoryID,
		                          DateTime modifiedDate,
		                          string name,
		                          int productCategoryID,
		                          Guid rowguid)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductCategoryID = productCategoryID.ToInt();
			this.ProductSubcategoryID = productSubcategoryID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int ProductCategoryID { get; set; }
		public int ProductSubcategoryID { get; set; }
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>900b3073dec6e97cbbc12a5b4c666ac5</Hash>
</Codenesium>*/