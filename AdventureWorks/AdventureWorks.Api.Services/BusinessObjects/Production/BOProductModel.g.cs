using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOProductModel: AbstractBusinessObject
	{
		public BOProductModel() : base()
		{}

		public void SetProperties(int productModelID,
		                          string catalogDescription,
		                          string instructions,
		                          DateTime modifiedDate,
		                          string name,
		                          Guid rowguid)
		{
			this.CatalogDescription = catalogDescription;
			this.Instructions = instructions;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ProductModelID = productModelID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public string CatalogDescription { get; private set; }
		public string Instructions { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public int ProductModelID { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7af3a0ca452ce834e82d56f98df5cd3a</Hash>
</Codenesium>*/