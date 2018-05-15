using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOTeam
	{
		public POCOTeam()
		{}

		public POCOTeam(
			int id,
			string name,
			int organizationId)
		{
			this.Id = id.ToInt();
			this.Name = name;

			this.OrganizationId = new ReferenceEntity<int>(organizationId,
			                                               nameof(ApiResponse.Organizations));
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> OrganizationId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrganizationIdValue { get; set; } = true;

		public bool ShouldSerializeOrganizationId()
		{
			return this.ShouldSerializeOrganizationIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeOrganizationIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c770408868bbecc0cf1365cac9681555</Hash>
</Codenesium>*/