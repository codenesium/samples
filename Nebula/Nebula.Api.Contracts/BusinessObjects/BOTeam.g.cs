using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class BOTeam:AbstractBusinessObject
	{
		public BOTeam() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int organizationId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.OrganizationId = organizationId.ToInt();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public int OrganizationId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ed4c735a6598540e66bd3a18bce2c41b</Hash>
</Codenesium>*/