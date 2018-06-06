using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>d3f9e28c0919edd8e81732f2508ef68c</Hash>
</Codenesium>*/