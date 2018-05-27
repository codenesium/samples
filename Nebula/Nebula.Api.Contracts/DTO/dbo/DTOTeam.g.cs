using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class DTOTeam: AbstractDTO
	{
		public DTOTeam() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int organizationId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.OrganizationId = organizationId.ToInt();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public int OrganizationId { get; set; }
	}
}

/*<Codenesium>
    <Hash>c52cf81ccf63b85781cd18a2fb76fa05</Hash>
</Codenesium>*/