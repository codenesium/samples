using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOSalesReason : AbstractBusinessObject
	{
		public AbstractBOSalesReason()
			: base()
		{
		}

		public virtual void SetProperties(int salesReasonID,
		                                  DateTime modifiedDate,
		                                  string name,
		                                  string reasonType)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ReasonType = reasonType;
			this.SalesReasonID = salesReasonID;
		}

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public string ReasonType { get; private set; }

		public int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>499af018d1c7ac10eb97743c5409c4a8</Hash>
</Codenesium>*/