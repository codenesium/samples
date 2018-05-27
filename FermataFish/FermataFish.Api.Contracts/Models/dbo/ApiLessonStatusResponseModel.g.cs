using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonStatusResponseModel: AbstractApiResponseModel
	{
		public ApiLessonStatusResponseModel() : base()
		{}

		public void SetProperties(
			int id,
			string name,
			int studioId)
		{
			this.Name = name;

			this.Id = new ReferenceEntity<int>(id,
			                                   nameof(ApiResponse.Studios));
			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         nameof(ApiResponse.Studios));
		}

		public ReferenceEntity<int> Id { get; set; }
		public string Name { get; set; }
		public ReferenceEntity<int> StudioId { get; set; }

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
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeStudioIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>877a1255f6e941f6a8ad77303ccfec63</Hash>
</Codenesium>*/