using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOProductModelProductDescriptionCulture: AbstractBusinessObject
	{
		public BOProductModelProductDescriptionCulture() : base()
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

		public string CultureID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductDescriptionID { get; private set; }
		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>23eed6d33076beee49a12307a7dab40d</Hash>
</Codenesium>*/