using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOLesson: AbstractBusinessObject
        {
                public BOLesson() : base()
                {
                }

                public void SetProperties(int id,
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
                        this.Id = id;
                        this.LessonStatusId = lessonStatusId;
                        this.ScheduledEndDate = scheduledEndDate;
                        this.ScheduledStartDate = scheduledStartDate;
                        this.StudentNotes = studentNotes;
                        this.StudioId = studioId;
                        this.TeacherNotes = teacherNotes;
                }

                public Nullable<DateTime> ActualEndDate { get; private set; }

                public Nullable<DateTime> ActualStartDate { get; private set; }

                public Nullable<decimal> BillAmount { get; private set; }

                public int Id { get; private set; }

                public int LessonStatusId { get; private set; }

                public Nullable<DateTime> ScheduledEndDate { get; private set; }

                public Nullable<DateTime> ScheduledStartDate { get; private set; }

                public string StudentNotes { get; private set; }

                public int StudioId { get; private set; }

                public string TeacherNotes { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9fa8287d3d72e8211721e89673fe1e88</Hash>
</Codenesium>*/