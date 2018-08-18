using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductProductPhoto : AbstractBusinessObject
	{
		public AbstractBOProductProductPhoto()
			: base()
		{
		}

		public virtual void SetProperties(int productID,
		                                  DateTime modifiedDate,
		                                  bool primary,
		                                  int productPhotoID)
		{
			this.ModifiedDate = modifiedDate;
			this.Primary = primary;
			this.ProductID = productID;
			this.ProductPhotoID = productPhotoID;
		}

		public DateTime ModifiedDate { get; private set; }

		public bool Primary { get; private set; }

		public int ProductID { get; private set; }

		public int ProductPhotoID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>36dd53377385319211ae903f22f169b8</Hash>
</Codenesium>*/