using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOTeam
	{
		public POCOTeam()
		{}

		public POCOTeam(int id,
		                string name,
		                int organizationId)
		{
			this.Id = id.ToInt();
			this.Name = name;

			OrganizationId = new ReferenceEntity<int>(organizationId,
			                                          "Organization");
		}

		public int Id {get; set;}
		public string Name {get; set;}
		public ReferenceEntity<int>OrganizationId {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrganizationIdValue {get; set;} = true;

		public bool ShouldSerializeOrganizationId()
		{
			return ShouldSerializeOrganizationIdValue;
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
    <Hash>9326126d4cd81526b658f2ba1a76ed63</Hash>
</Codenesium>*/