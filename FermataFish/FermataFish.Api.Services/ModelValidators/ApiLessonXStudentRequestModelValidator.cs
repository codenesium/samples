using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiLessonXStudentRequestModelValidator: AbstractApiLessonXStudentRequestModelValidator, IApiLessonXStudentRequestModelValidator
        {
                public ApiLessonXStudentRequestModelValidator(ILessonXStudentRepository lessonXStudentRepository)
                        : base(lessonXStudentRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentRequestModel model)
                {
                        this.LessonIdRules();
                        this.StudentIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentRequestModel model)
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
    <Hash>2194ba445ea93df407018d207708db6a</Hash>
</Codenesium>*/