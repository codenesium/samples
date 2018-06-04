using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOCulture: AbstractBusinessObject
	{
		public BOCulture() : base()
		{}

		public void SetProperties(string cultureID,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.CultureID = cultureID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CultureID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3e3a7b1eb8264b4851925ebebffc8cf9</Hash>
</Codenesium>*/