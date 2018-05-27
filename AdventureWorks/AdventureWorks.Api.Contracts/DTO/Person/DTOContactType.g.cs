using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOContactType: AbstractDTO
	{
		public DTOContactType() : base()
		{}

		public void SetProperties(int contactTypeID,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.ContactTypeID = contactTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public int ContactTypeID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>5e97a2c9aa85c4cfd50e8c52beb626a3</Hash>
</Codenesium>*/