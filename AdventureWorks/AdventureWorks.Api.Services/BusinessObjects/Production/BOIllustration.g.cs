using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOIllustration: AbstractBusinessObject
	{
		public BOIllustration() : base()
		{}

		public void SetProperties(int illustrationID,
		                          string diagram,
		                          DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string Diagram { get; private set; }
		public int IllustrationID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>28e7bec5823897c76b1c05c4f4619703</Hash>
</Codenesium>*/