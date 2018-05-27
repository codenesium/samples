using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class DTOLinkLog: AbstractDTO
	{
		public DTOLinkLog() : base()
		{}

		public void SetProperties(int id,
		                          DateTime dateEntered,
		                          int linkId,
		                          string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.Id = id.ToInt();
			this.LinkId = linkId.ToInt();
			this.Log = log;
		}

		public DateTime DateEntered { get; set; }
		public int Id { get; set; }
		public int LinkId { get; set; }
		public string Log { get; set; }
	}
}

/*<Codenesium>
    <Hash>b7f8b1b376bba45ca1a1c551e7c0976a</Hash>
</Codenesium>*/