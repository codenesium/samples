using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class BOChainStatus: AbstractBusinessObject
	{
		public BOChainStatus() : base()
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
    <Hash>24dad04f09e22e9bec141d8495e40cc1</Hash>
</Codenesium>*/