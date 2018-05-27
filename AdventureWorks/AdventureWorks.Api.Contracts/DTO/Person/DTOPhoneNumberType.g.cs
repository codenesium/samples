using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOPhoneNumberType: AbstractDTO
	{
		public DTOPhoneNumberType() : base()
		{}

		public void SetProperties(int phoneNumberTypeID,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public int PhoneNumberTypeID { get; set; }
	}
}

/*<Codenesium>
    <Hash>f672f3b097d01a3ed3b46713767a4ef0</Hash>
</Codenesium>*/