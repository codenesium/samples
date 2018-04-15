using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class LessonModel
	{
		public LessonModel()
		{}

		public LessonModel(
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
			this.ScheduledStartDate = scheduledStartDate.ToNullableDateTime();
			this.ScheduledEndDate = scheduledEndDate.ToNullableDateTime();
			this.ActualStartDate = actualStartDate.ToNullableDateTime();
			this.ActualEndDate = actualEndDate.ToNullableDateTime();
			this.LessonStatusId = lessonStatusId.ToInt();
			this.TeacherNotes = teacherNotes.ToString();
			this.StudentNotes = studentNotes.ToString();
			this.BillAmount = billAmount.ToNullableDecimal();
			this.StudioId = studioId.ToInt();
		}

		private Nullable<DateTime> scheduledStartDate;

		public Nullable<DateTime> ScheduledStartDate
		{
			get
			{
				return this.scheduledStartDate.IsEmptyOrZeroOrNull() ? null : this.scheduledStartDate;
			}

			set
			{
				this.scheduledStartDate = value;
			}
		}

		private Nullable<DateTime> scheduledEndDate;

		public Nullable<DateTime> ScheduledEndDate
		{
			get
			{
				return this.scheduledEndDate.IsEmptyOrZeroOrNull() ? null : this.scheduledEndDate;
			}

			set
			{
				this.scheduledEndDate = value;
			}
		}

		private Nullable<DateTime> actualStartDate;

		public Nullable<DateTime> ActualStartDate
		{
			get
			{
				return this.actualStartDate.IsEmptyOrZeroOrNull() ? null : this.actualStartDate;
			}

			set
			{
				this.actualStartDate = value;
			}
		}

		private Nullable<DateTime> actualEndDate;

		public Nullable<DateTime> ActualEndDate
		{
			get
			{
				return this.actualEndDate.IsEmptyOrZeroOrNull() ? null : this.actualEndDate;
			}

			set
			{
				this.actualEndDate = value;
			}
		}

		private int lessonStatusId;

		[Required]
		public int LessonStatusId
		{
			get
			{
				return this.lessonStatusId;
			}

			set
			{
				this.lessonStatusId = value;
			}
		}

		private string teacherNotes;

		public string TeacherNotes
		{
			get
			{
				return this.teacherNotes.IsEmptyOrZeroOrNull() ? null : this.teacherNotes;
			}

			set
			{
				this.teacherNotes = value;
			}
		}

		private string studentNotes;

		public string StudentNotes
		{
			get
			{
				return this.studentNotes.IsEmptyOrZeroOrNull() ? null : this.studentNotes;
			}

			set
			{
				this.studentNotes = value;
			}
		}

		private Nullable<decimal> billAmount;

		public Nullable<decimal> BillAmount
		{
			get
			{
				return this.billAmount.IsEmptyOrZeroOrNull() ? null : this.billAmount;
			}

			set
			{
				this.billAmount = value;
			}
		}

		private int studioId;

		[Required]
		public int StudioId
		{
			get
			{
				return this.studioId;
			}

			set
			{
				this.studioId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8efeea9cf17c7346fd2bc773e05eda59</Hash>
</Codenesium>*/