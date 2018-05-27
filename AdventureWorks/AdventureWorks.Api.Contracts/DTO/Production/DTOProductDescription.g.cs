using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductDescription: AbstractDTO
	{
		public DTOProductDescription() : base()
		{}

		public void SetProperties(int productDescriptionID,
		                          string description,
		                          DateTime modifiedDate,
		                          Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public string Description { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductDescriptionID { get; set; }
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>e8643ba95a47161d7be71d7b75a401c6</Hash>
</Codenesium>*/