using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiLessonResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
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
                        this.Id = id;
                        this.ActualEndDate = actualEndDate;
                        this.ActualStartDate = actualStartDate;
                        this.BillAmount = billAmount;
                        this.LessonStatusId = lessonStatusId;
                        this.ScheduledEndDate = scheduledEndDate;
                        this.ScheduledStartDate = scheduledStartDate;
                        this.StudentNotes = studentNotes;
                        this.StudioId = studioId;
                        this.TeacherNotes = teacherNotes;

                        this.LessonStatusIdEntity = nameof(ApiResponse.LessonStatus);
                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public DateTime? ActualEndDate { get; private set; }

                public DateTime? ActualStartDate { get; private set; }

                public decimal? BillAmount { get; private set; }

                public int Id { get; private set; }

                public int LessonStatusId { get; private set; }

                public string LessonStatusIdEntity { get; set; }

                public DateTime? ScheduledEndDate { get; private set; }

                public DateTime? ScheduledStartDate { get; private set; }

                public string StudentNotes { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }

                public string TeacherNotes { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1517a5ce15445c78265d9e5038026544</Hash>
</Codenesium>*/