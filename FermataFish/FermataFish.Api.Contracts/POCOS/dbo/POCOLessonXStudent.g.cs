using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOLessonXStudent
	{
		public POCOLessonXStudent()
		{}

		public POCOLessonXStudent(
			int lessonId,
			int studentId,
			int id)
		{
			this.Id = id.ToInt();

			this.LessonId = new ReferenceEntity<int>(lessonId,
			                                         nameof(ApiResponse.Lessons));
			this.StudentId = new ReferenceEntity<int>(studentId,
			                                          nameof(ApiResponse.Students));
		}

		public ReferenceEntity<int> LessonId { get; set; }
		public ReferenceEntity<int> StudentId { get; set; }
		public int Id { get; set; }

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

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeLessonIdValue = false;
			this.ShouldSerializeStudentIdValue = false;
			this.ShouldSerializeIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>ccc950111beb4bacdf343713e6bf5e1d</Hash>
</Codenesium>*/