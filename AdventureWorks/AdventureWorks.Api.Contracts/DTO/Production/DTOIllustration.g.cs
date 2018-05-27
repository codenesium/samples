using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOIllustration: AbstractDTO
	{
		public DTOIllustration() : base()
		{}

		public void SetProperties(int illustrationID,
		                          string diagram,
		                          DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public string Diagram { get; set; }
		public int IllustrationID { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>3c893d41569042eb368ad1d6e9670f69</Hash>
</Codenesium>*/