using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOProductCategory: AbstractBusinessObject
	{
		public BOProductCategory() : base()
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

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public int ProductCategoryID { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ae03e350088caa0e7fc17d2c988335ba</Hash>
</Codenesium>*/