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
			                                          "Student");
			this.FamilyId = new ReferenceEntity<int>(familyId,
			                                         "Family");
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
    <Hash>58be3d2f60a6d175f5670db0a88b15b2</Hash>
</Codenesium>*/