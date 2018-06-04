using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class BOOrganization: AbstractBusinessObject
	{
		public BOOrganization() : base()
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
    <Hash>d9d5e8bb6b0b000db07d89e97d62936b</Hash>
</Codenesium>*/