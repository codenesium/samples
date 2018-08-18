using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOAddressType : AbstractBusinessObject
	{
		public AbstractBOAddressType()
			: base()
		{
		}

		public virtual void SetProperties(int addressTypeID,
		                                  DateTime modifiedDate,
		                                  string name,
		                                  Guid rowguid)
		{
			this.AddressTypeID = addressTypeID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		public int AddressTypeID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>46d2f72601cf13c0bfeddc1645e3315d</Hash>
</Codenesium>*/