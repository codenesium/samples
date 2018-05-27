using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductModel: AbstractDTO
	{
		public DTOProductModel() : base()
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

		public string CatalogDescription { get; set; }
		public string Instructions { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int ProductModelID { get; set; }
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>379a5fee8cce70657978bdacda22ed14</Hash>
</Codenesium>*/