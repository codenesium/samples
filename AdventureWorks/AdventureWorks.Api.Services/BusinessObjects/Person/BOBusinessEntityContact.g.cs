using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOBusinessEntityContact: AbstractBusinessObject
	{
		public BOBusinessEntityContact() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          int contactTypeID,
		                          DateTime modifiedDate,
		                          int personID,
		                          Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ContactTypeID = contactTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PersonID = personID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public int BusinessEntityID { get; private set; }
		public int ContactTypeID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int PersonID { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>85639cc846ed2518855fa10c456df33d</Hash>
</Codenesium>*/