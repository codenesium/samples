using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonRequestModel: AbstractApiRequestModel
        {
                public ApiLessonRequestModel() : base()
                {
                }

                public void SetProperties(
                        Nullable<DateTime> actualEndDate,
                        Nullable<DateTime> actualStartDate,
                        Nullable<decimal> billAmount,
                        int lessonStatusId,
                        Nullable<DateTime> scheduledEndDate,
                        Nullable<DateTime> scheduledStartDate,
                        string studentNotes,
                        int studioId,
                        string teacherNotes)
                {
                        this.ActualEndDate = actualEndDate;
                        this.ActualStartDate = actualStartDate;
                        this.BillAmount = billAmount;
                        this.LessonStatusId = lessonStatusId;
                        this.ScheduledEndDate = scheduledEndDate;
                        this.ScheduledStartDate = scheduledStartDate;
                        this.StudentNotes = studentNotes;
                        this.StudioId = studioId;
                        this.TeacherNotes = teacherNotes;
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
        }
}

/*<Codenesium>
    <Hash>11fdd78f1a8a7daa99c9a8c362f4fdd6</Hash>
</Codenesium>*/