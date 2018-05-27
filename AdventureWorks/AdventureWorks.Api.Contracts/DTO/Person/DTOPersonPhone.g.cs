using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOPersonPhone: AbstractDTO
	{
		public DTOPersonPhone() : base()
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

		public int BusinessEntityID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string PhoneNumber { get; set; }
		public int PhoneNumberTypeID { get; set; }
	}
}

/*<Codenesium>
    <Hash>325226f7acfad81e8b77ede0c51d09f6</Hash>
</Codenesium>*/