using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductDescription : AbstractBusinessObject
	{
		public AbstractBOProductDescription()
			: base()
		{
		}

		public virtual void SetProperties(int productDescriptionID,
		                                  string description,
		                                  DateTime modifiedDate,
		                                  Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate;
			this.ProductDescriptionID = productDescriptionID;
			this.Rowguid = rowguid;
		}

		public string Description { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public int ProductDescriptionID { get; private set; }

		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e1431f31d8d28a03fcec0b8756f9a103</Hash>
</Codenesium>*/