using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductSubcategory: AbstractBusinessObject
	{
		public BOProductSubcategory() : base()
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

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public int ProductCategoryID { get; private set; }
		public int ProductSubcategoryID { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>09106f1b355336983fc40738aa90249f</Hash>
</Codenesium>*/