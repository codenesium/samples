using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonRequestModel : AbstractApiRequestModel
        {
                public ApiLessonRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime? actualEndDate,
                        DateTime? actualStartDate,
                        decimal? billAmount,
                        int lessonStatusId,
                        DateTime? scheduledEndDate,
                        DateTime? scheduledStartDate,
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

                private DateTime? actualEndDate;

                public DateTime? ActualEndDate
                {
                        get
                        {
                                return this.actualEndDate;
                        }

                        set
                        {
                                this.actualEndDate = value;
                        }
                }

                private DateTime? actualStartDate;

                public DateTime? ActualStartDate
                {
                        get
                        {
                                return this.actualStartDate;
                        }

                        set
                        {
                                this.actualStartDate = value;
                        }
                }

                private decimal? billAmount;

                public decimal? BillAmount
                {
                        get
                        {
                                return this.billAmount;
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

                private DateTime? scheduledEndDate;

                public DateTime? ScheduledEndDate
                {
                        get
                        {
                                return this.scheduledEndDate;
                        }

                        set
                        {
                                this.scheduledEndDate = value;
                        }
                }

                private DateTime? scheduledStartDate;

                public DateTime? ScheduledStartDate
                {
                        get
                        {
                                return this.scheduledStartDate;
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
                                return this.studentNotes;
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
                                return this.teacherNotes;
                        }

                        set
                        {
                                this.teacherNotes = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>85839ace5a7077094225b72c92be5514</Hash>
</Codenesium>*/