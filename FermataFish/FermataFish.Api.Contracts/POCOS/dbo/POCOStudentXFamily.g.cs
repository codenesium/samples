using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOStudentXFamily
	{
		public POCOStudentXFamily()
		{}

		public POCOStudentXFamily(
			int id,
			int studentId,
			int familyId)
		{
			this.Id = id.ToInt();

			this.StudentId = new ReferenceEntity<int>(studentId,
			                                          nameof(ApiResponse.Students));
			this.FamilyId = new ReferenceEntity<int>(familyId,
			                                         nameof(ApiResponse.Families));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> StudentId { get; set; }
		public ReferenceEntity<int> FamilyId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStudentIdValue { get; set; } = true;

		public bool ShouldSerializeStudentId()
		{
			return this.ShouldSerializeStudentIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFamilyIdValue { get; set; } = true;

		public bool ShouldSerializeFamilyId()
		{
			return this.ShouldSerializeFamilyIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeStudentIdValue = false;
			this.ShouldSerializeFamilyIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9a6d3f4cc29808fdd18c1e4b1419b400</Hash>
</Codenesium>*/