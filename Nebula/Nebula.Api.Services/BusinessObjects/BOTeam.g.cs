using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
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
    <Hash>54478f8448cb53170c865aa53624235f</Hash>
</Codenesium>*/