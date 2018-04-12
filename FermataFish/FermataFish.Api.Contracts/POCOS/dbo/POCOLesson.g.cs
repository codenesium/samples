using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOLesson
	{
		public POCOLesson()
		{}

		public POCOLesson(
			int id,
			Nullable<DateTime> scheduledStartDate,
			Nullable<DateTime> scheduledEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<DateTime> actualEndDate,
			int lessonStatusId,
			string teacherNotes,
			string studentNotes,
			Nullable<decimal> billAmount,
			int studioId)
		{
			this.Id = id.ToInt();
			this.ScheduledStartDate = scheduledStartDate.ToNullableDateTime();
			this.ScheduledEndDate = scheduledEndDate.ToNullableDateTime();
			this.ActualStartDate = actualStartDate;
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.TeacherNotes = teacherNotes;
			this.StudentNotes = studentNotes;
			this.BillAmount = billAmount;

			this.LessonStatusId = new ReferenceEntity<int>(lessonStatusId,
			                                               "LessonStatus");
			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         "Studio");
		}

		public int Id { get; set; }
		public Nullable<DateTime> ScheduledStartDate { get; set; }
		public Nullable<DateTime> ScheduledEndDate { get; set; }
		public Nullable<DateTime> ActualStartDate { get; set; }
		public Nullable<DateTime> ActualEndDate { get; set; }
		public ReferenceEntity<int> LessonStatusId { get; set; }
		public string TeacherNotes { get; set; }
		public string StudentNotes { get; set; }
		public Nullable<decimal> BillAmount { get; set; }
		public ReferenceEntity<int> StudioId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScheduledStartDateValue { get; set; } = true;

		public bool ShouldSerializeScheduledStartDate()
		{
			return this.ShouldSerializeScheduledStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeScheduledEndDateValue { get; set; } = true;

		public bool ShouldSerializeScheduledEndDate()
		{
			return this.ShouldSerializeScheduledEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualStartDateValue { get; set; } = true;

		public bool ShouldSerializeActualStartDate()
		{
			return this.ShouldSerializeActualStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeActualEndDateValue { get; set; } = true;

		public bool ShouldSerializeActualEndDate()
		{
			return this.ShouldSerializeActualEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonStatusIdValue { get; set; } = true;

		public bool ShouldSerializeLessonStatusId()
		{
			return this.ShouldSerializeLessonStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherNotesValue { get; set; } = true;

		public bool ShouldSerializeTeacherNotes()
		{
			return this.ShouldSerializeTeacherNotesValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStudentNotesValue { get; set; } = true;

		public bool ShouldSerializeStudentNotes()
		{
			return this.ShouldSerializeStudentNotesValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBillAmountValue { get; set; } = true;

		public bool ShouldSerializeBillAmount()
		{
			return this.ShouldSerializeBillAmountValue;
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
			this.ShouldSerializeScheduledStartDateValue = false;
			this.ShouldSerializeScheduledEndDateValue = false;
			this.ShouldSerializeActualStartDateValue = false;
			this.ShouldSerializeActualEndDateValue = false;
			this.ShouldSerializeLessonStatusIdValue = false;
			this.ShouldSerializeTeacherNotesValue = false;
			this.ShouldSerializeStudentNotesValue = false;
			this.ShouldSerializeBillAmountValue = false;
			this.ShouldSerializeStudioIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>529863f21f3df221d139c122a103aec0</Hash>
</Codenesium>*/