using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonXTeacherResponseModel: AbstractApiResponseModel
	{
		public ApiLessonXTeacherResponseModel() : base()
		{}

		public void SetProperties(
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
    <Hash>7825e49b5b4cf954ca87be8c02932d7f</Hash>
</Codenesium>*/