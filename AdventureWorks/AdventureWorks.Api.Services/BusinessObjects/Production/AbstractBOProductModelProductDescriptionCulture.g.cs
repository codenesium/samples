using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductModelProductDescriptionCulture : AbstractBusinessObject
	{
		public AbstractBOProductModelProductDescriptionCulture()
			: base()
		{
		}

		public virtual void SetProperties(int productModelID,
		                                  string cultureID,
		                                  DateTime modifiedDate,
		                                  int productDescriptionID)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate;
			this.ProductDescriptionID = productDescriptionID;
			this.ProductModelID = productModelID;
		}

		public string CultureID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public int ProductDescriptionID { get; private set; }

		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9cde8ac52134e95588da268534e5c77b</Hash>
</Codenesium>*/