using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiLessonResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        Nullable<DateTime> actualEndDate,
                        Nullable<DateTime> actualStartDate,
                        Nullable<decimal> billAmount,
                        int id,
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

                        this.LessonStatusIdEntity = nameof(ApiResponse.LessonStatus);
                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public Nullable<DateTime> ActualEndDate { get; private set; }

                public Nullable<DateTime> ActualStartDate { get; private set; }

                public Nullable<decimal> BillAmount { get; private set; }

                public int Id { get; private set; }

                public int LessonStatusId { get; private set; }

                public string LessonStatusIdEntity { get; set; }

                public Nullable<DateTime> ScheduledEndDate { get; private set; }

                public Nullable<DateTime> ScheduledStartDate { get; private set; }

                public string StudentNotes { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }

                public string TeacherNotes { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeActualEndDateValue { get; set; } = true;

                public bool ShouldSerializeActualEndDate()
                {
                        return this.ShouldSerializeActualEndDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeActualStartDateValue { get; set; } = true;

                public bool ShouldSerializeActualStartDate()
                {
                        return this.ShouldSerializeActualStartDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeBillAmountValue { get; set; } = true;

                public bool ShouldSerializeBillAmount()
                {
                        return this.ShouldSerializeBillAmountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLessonStatusIdValue { get; set; } = true;

                public bool ShouldSerializeLessonStatusId()
                {
                        return this.ShouldSerializeLessonStatusIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeScheduledEndDateValue { get; set; } = true;

                public bool ShouldSerializeScheduledEndDate()
                {
                        return this.ShouldSerializeScheduledEndDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeScheduledStartDateValue { get; set; } = true;

                public bool ShouldSerializeScheduledStartDate()
                {
                        return this.ShouldSerializeScheduledStartDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudentNotesValue { get; set; } = true;

                public bool ShouldSerializeStudentNotes()
                {
                        return this.ShouldSerializeStudentNotesValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudioIdValue { get; set; } = true;

                public bool ShouldSerializeStudioId()
                {
                        return this.ShouldSerializeStudioIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTeacherNotesValue { get; set; } = true;

                public bool ShouldSerializeTeacherNotes()
                {
                        return this.ShouldSerializeTeacherNotesValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeActualEndDateValue = false;
                        this.ShouldSerializeActualStartDateValue = false;
                        this.ShouldSerializeBillAmountValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLessonStatusIdValue = false;
                        this.ShouldSerializeScheduledEndDateValue = false;
                        this.ShouldSerializeScheduledStartDateValue = false;
                        this.ShouldSerializeStudentNotesValue = false;
                        this.ShouldSerializeStudioIdValue = false;
                        this.ShouldSerializeTeacherNotesValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>f3786c4bff0e15b0678b001a82db8390</Hash>
</Codenesium>*/