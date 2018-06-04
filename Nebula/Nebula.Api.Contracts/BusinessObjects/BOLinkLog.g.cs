using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
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
    <Hash>9a3f2dd04217888c2bd8bb226e0f8b89</Hash>
</Codenesium>*/