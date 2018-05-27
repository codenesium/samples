using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOScrapReason: AbstractDTO
	{
		public DTOScrapReason() : base()
		{}

		public void SetProperties(short scrapReasonID,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ScrapReasonID = scrapReasonID;
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public short ScrapReasonID { get; set; }
	}
}

/*<Codenesium>
    <Hash>0a32562cd824268c13d3d611c7de7e45</Hash>
</Codenesium>*/