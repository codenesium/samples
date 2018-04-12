using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOLessonStatus
	{
		public POCOLessonStatus()
		{}

		public POCOLessonStatus(
			string name,
			int id,
			int studioId)
		{
			this.Name = name;

			this.Id = new ReferenceEntity<int>(id,
			                                   "Studio");
			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         "Studio");
		}

		public string Name { get; set; }
		public ReferenceEntity<int> Id { get; set; }
		public ReferenceEntity<int> StudioId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStudioIdValue { get; set; } = true;

		public bool ShouldSerializeStudioId()
		{
			return this.ShouldSerializeStudioIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeStudioIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>1ff80baf35e91ffea11e1f1925854de1</Hash>
</Codenesium>*/