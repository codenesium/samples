using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOPhoneNumberType: AbstractBusinessObject
	{
		public BOPhoneNumberType() : base()
		{}

		public void SetProperties(int phoneNumberTypeID,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public int PhoneNumberTypeID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>38533542c04852101074f88315f8d4d3</Hash>
</Codenesium>*/