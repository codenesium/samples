using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiLessonXTeacherRequestModelValidator: AbstractApiLessonXTeacherRequestModelValidator, IApiLessonXTeacherRequestModelValidator
        {
                public ApiLessonXTeacherRequestModelValidator(ILessonXTeacherRepository lessonXTeacherRepository)
                        : base(lessonXTeacherRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model)
                {
                        this.LessonIdRules();
                        this.StudentIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model)
                {
                        this.LessonIdRules();
                        this.StudentIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>883d24e9477cc54c29b17f4f6bf40300</Hash>
</Codenesium>*/