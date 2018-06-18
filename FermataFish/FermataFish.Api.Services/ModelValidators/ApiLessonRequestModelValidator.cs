using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiLessonRequestModelValidator: AbstractApiLessonRequestModelValidator, IApiLessonRequestModelValidator
        {
                public ApiLessonRequestModelValidator(ILessonRepository lessonRepository)
                        : base(lessonRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLessonRequestModel model)
                {
                        this.ActualEndDateRules();
                        this.ActualStartDateRules();
                        this.BillAmountRules();
                        this.LessonStatusIdRules();
                        this.ScheduledEndDateRules();
                        this.ScheduledStartDateRules();
                        this.StudentNotesRules();
                        this.StudioIdRules();
                        this.TeacherNotesRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonRequestModel model)
                {
                        this.ActualEndDateRules();
                        this.ActualStartDateRules();
                        this.BillAmountRules();
                        this.LessonStatusIdRules();
                        this.ScheduledEndDateRules();
                        this.ScheduledStartDateRules();
                        this.StudentNotesRules();
                        this.StudioIdRules();
                        this.TeacherNotesRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>783410929fa741bf833ba57fa25154ac</Hash>
</Codenesium>*/