using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOEmailAddress: AbstractBusinessObject
	{
		public BOEmailAddress() : base()
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

		public int BusinessEntityID { get; private set; }
		public string EmailAddress1 { get; private set; }
		public int EmailAddressID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>87957b896e7653be5e0b71196ae89f62</Hash>
</Codenesium>*/