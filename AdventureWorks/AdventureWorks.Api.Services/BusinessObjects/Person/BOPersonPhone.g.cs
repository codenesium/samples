using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>aec075d8d4caa7a4958b6bd2b6895fd4</Hash>
</Codenesium>*/