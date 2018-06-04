using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
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
    <Hash>844a2d7f5603a122dfacdfbc3a238750</Hash>
</Codenesium>*/