using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOBusinessEntity : AbstractBusinessObject
	{
		public AbstractBOBusinessEntity()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
		                                  DateTime modifiedDate,
		                                  Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		public int BusinessEntityID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0accc4925e87680395ca0d2455f50d9d</Hash>
</Codenesium>*/