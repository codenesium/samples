using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiStudentXFamilyRequestModelValidator: AbstractApiStudentXFamilyRequestModelValidator, IApiStudentXFamilyRequestModelValidator
        {
                public ApiStudentXFamilyRequestModelValidator(IStudentXFamilyRepository studentXFamilyRepository)
                        : base(studentXFamilyRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyRequestModel model)
                {
                        this.FamilyIdRules();
                        this.StudentIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyRequestModel model)
                {
                        this.FamilyIdRules();
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
    <Hash>5ee7396d56a9286083439b3972e0c275</Hash>
</Codenesium>*/