using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>abd189c851578ebe657d71ba5019c95a</Hash>
</Codenesium>*/