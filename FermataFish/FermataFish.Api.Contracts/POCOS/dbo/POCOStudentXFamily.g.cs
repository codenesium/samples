using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOStudentXFamily: AbstractPOCO
	{
		public POCOStudentXFamily() : base()
		{}

		public POCOStudentXFamily(
			int familyId,
			int id,
			int studentId)
		{
			this.Id = id.ToInt();

			this.FamilyId = new ReferenceEntity<int>(familyId,
			                                         nameof(ApiResponse.Families));
			this.StudentId = new ReferenceEntity<int>(studentId,
			                                          nameof(ApiResponse.Students));
		}

		public ReferenceEntity<int> FamilyId { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> StudentId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeFamilyIdValue { get; set; } = true;

		public bool ShouldSerializeFamilyId()
		{
			return this.ShouldSerializeFamilyIdValue;
		}

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

		public void DisableAllFields()
		{
			this.ShouldSerializeFamilyIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeStudentIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c8b1f1f9d4b014caeb4ca99761d1a611</Hash>
</Codenesium>*/