using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOLessonXStudent: AbstractPOCO
	{
		public POCOLessonXStudent() : base()
		{}

		public POCOLessonXStudent(
			int id,
			int lessonId,
			int studentId)
		{
			this.Id = id.ToInt();

			this.LessonId = new ReferenceEntity<int>(lessonId,
			                                         nameof(ApiResponse.Lessons));
			this.StudentId = new ReferenceEntity<int>(studentId,
			                                          nameof(ApiResponse.Students));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> LessonId { get; set; }
		public ReferenceEntity<int> StudentId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonIdValue { get; set; } = true;

		public bool ShouldSerializeLessonId()
		{
			return this.ShouldSerializeLessonIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStudentIdValue { get; set; } = true;

		public bool ShouldSerializeStudentId()
		{
			return this.ShouldSerializeStudentIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLessonIdValue = false;
			this.ShouldSerializeStudentIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9060d5c9ef4c5b3c5d7b495945ca9916</Hash>
</Codenesium>*/