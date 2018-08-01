using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOPhoneNumberType : AbstractBusinessObject
	{
		public AbstractBOPhoneNumberType()
			: base()
		{
		}

		public virtual void SetProperties(int phoneNumberTypeID,
		                                  DateTime modifiedDate,
		                                  string name)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.PhoneNumberTypeID = phoneNumberTypeID;
		}

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>36eb579dc746f11c659187e2e71b0f4c</Hash>
</Codenesium>*/