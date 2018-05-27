using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiTeamResponseModel: AbstractApiResponseModel
	{
		public ApiTeamResponseModel() : base()
		{}

		public void SetProperties(
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
    <Hash>c89c15a52f6696e8c4c744bf0cb9e40d</Hash>
</Codenesium>*/