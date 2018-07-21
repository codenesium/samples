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

                [Required]
                [JsonProperty]
                public DateTime? ActualEndDate { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime? ActualStartDate { get; private set; }

                [Required]
                [JsonProperty]
                public decimal? BillAmount { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int LessonStatusId { get; private set; }

                [JsonProperty]
                public string LessonStatusIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public DateTime? ScheduledEndDate { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime? ScheduledStartDate { get; private set; }

                [Required]
                [JsonProperty]
                public string StudentNotes { get; private set; }

                [Required]
                [JsonProperty]
                public int StudioId { get; private set; }

                [JsonProperty]
                public string StudioIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public string TeacherNotes { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a1990fc8e9b573fb23548ba0a29973aa</Hash>
</Codenesium>*/