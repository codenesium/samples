using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOBusinessEntityContact: AbstractDTO
	{
		public DTOBusinessEntityContact() : base()
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

		public int BusinessEntityID { get; set; }
		public int ContactTypeID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int PersonID { get; set; }
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>b9b209aa1276e737b39aa9a2f6c83af2</Hash>
</Codenesium>*/