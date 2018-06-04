using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOPersonPhone: AbstractBusinessObject
	{
		public BOPersonPhone() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          DateTime modifiedDate,
		                          string phoneNumber,
		                          int phoneNumberTypeID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PhoneNumber = phoneNumber;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		public int BusinessEntityID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string PhoneNumber { get; private set; }
		public int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e8e3f401f258354a1228ca647586a3e1</Hash>
</Codenesium>*/