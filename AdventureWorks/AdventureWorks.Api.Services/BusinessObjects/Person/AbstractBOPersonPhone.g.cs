using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOPersonPhone : AbstractBusinessObject
	{
		public AbstractBOPersonPhone()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
		                                  DateTime modifiedDate,
		                                  string phoneNumber,
		                                  int phoneNumberTypeID)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID;
		}

		public int BusinessEntityID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string PhoneNumber { get; private set; }

		public int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5c8dbbb7e2b5be158fd24125330fbaea</Hash>
</Codenesium>*/