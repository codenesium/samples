using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class BOLinkStatus: AbstractBusinessObject
	{
		public BOLinkStatus() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1ed1d637a8fd1799cf09855e2fb65dc1</Hash>
</Codenesium>*/