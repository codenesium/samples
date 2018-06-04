using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceResponseModel: AbstractApiResponseModel
	{
		public ApiSpaceResponseModel() : base()
		{}

		public void SetProperties(
			string description,
			int id,
			string name,
			int studioId)
		{
			this.Description = description;
			this.Id = id.ToInt();
			this.Name = name;
			this.StudioId = studioId.ToInt();

			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		public string Description { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int StudioId { get; private set; }
		public string StudioIdEntity { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

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
		public bool ShouldSerializeStudioIdValue { get; set; } = true;

		public bool ShouldSerializeStudioId()
		{
			return this.ShouldSerializeStudioIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeStudioIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9d57e44f9a0623432388b7c1aa8faebf</Hash>
</Codenesium>*/