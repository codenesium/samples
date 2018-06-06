using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
	public partial class BOLinkLog: AbstractBusinessObject
	{
		public BOLinkLog() : base()
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

		public DateTime DateEntered { get; private set; }
		public int Id { get; private set; }
		public int LinkId { get; private set; }
		public string Log { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f7c5469f5de9f05df9980bd0b069ef1f</Hash>
</Codenesium>*/