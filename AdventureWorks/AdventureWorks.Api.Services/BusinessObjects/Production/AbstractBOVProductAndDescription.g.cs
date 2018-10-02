using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOVProductAndDescription : AbstractBusinessObject
	{
		public AbstractBOVProductAndDescription()
			: base()
		{
		}

		public virtual void SetProperties(string cultureID,
		                                  string description,
		                                  string name,
		                                  int productID,
		                                  string productModel)
		{
			this.CultureID = cultureID;
			this.Description = description;
			this.Name = name;
			this.ProductID = productID;
			this.ProductModel = productModel;
		}

		public string CultureID { get; private set; }

		public string Description { get; private set; }

		public string Name { get; private set; }

		public int ProductID { get; private set; }

		public string ProductModel { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7d28e64f1045df5ea25faec63812c625</Hash>
</Codenesium>*/