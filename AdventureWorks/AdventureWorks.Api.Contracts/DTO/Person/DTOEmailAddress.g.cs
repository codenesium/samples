using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOEmailAddress: AbstractDTO
	{
		public DTOEmailAddress() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          string emailAddress1,
		                          int emailAddressID,
		                          DateTime modifiedDate,
		                          Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.EmailAddress1 = emailAddress1;
			this.EmailAddressID = emailAddressID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		public int BusinessEntityID { get; set; }
		public string EmailAddress1 { get; set; }
		public int EmailAddressID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>dd6617b6813339646d3db595b9d14150</Hash>
</Codenesium>*/