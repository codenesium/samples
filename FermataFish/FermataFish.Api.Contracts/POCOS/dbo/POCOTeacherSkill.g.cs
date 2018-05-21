using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOTeacherSkill: AbstractPOCO
	{
		public POCOTeacherSkill() : base()
		{}

		public POCOTeacherSkill(
			int id,
			string name,
			int studioId)
		{
			this.Id = id.ToInt();
			this.Name = name;

			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         nameof(ApiResponse.Studios));
		}

		public int Id { get; set; }
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
    <Hash>211f8afb96ec6d93d492c917d5ac2541</Hash>
</Codenesium>*/