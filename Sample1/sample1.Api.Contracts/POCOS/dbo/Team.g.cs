using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample1NS.Api.Contracts
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
    <Hash>4a0d4b5b9323c5382c0a9582daa374a3</Hash>
</Codenesium>*/