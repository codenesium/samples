using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductModelProductDescriptionCulture: AbstractDTO
	{
		public DTOProductModelProductDescriptionCulture() : base()
		{}

		public void SetProperties(int productModelID,
		                          string cultureID,
		                          DateTime modifiedDate,
		                          int productDescriptionID)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.ProductModelID = productModelID.ToInt();
		}

		public string CultureID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductDescriptionID { get; set; }
		public int ProductModelID { get; set; }
	}
}

/*<Codenesium>
    <Hash>7fe0d13da100e29443ba814b80d9ad61</Hash>
</Codenesium>*/