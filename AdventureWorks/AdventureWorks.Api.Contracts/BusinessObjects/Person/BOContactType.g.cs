using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOContactType: AbstractBusinessObject
	{
		public BOContactType() : base()
		{}

		public void SetProperties(int contactTypeID,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.ContactTypeID = contactTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public int ContactTypeID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4477650b651349205eded77149765a2f</Hash>
</Codenesium>*/