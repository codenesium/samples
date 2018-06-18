using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiStudentRequestModelValidator: AbstractApiStudentRequestModelValidator, IApiStudentRequestModelValidator
        {
                public ApiStudentRequestModelValidator(IStudentRepository studentRepository)
                        : base(studentRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiStudentRequestModel model)
                {
                        this.BirthdayRules();
                        this.EmailRules();
                        this.EmailRemindersEnabledRules();
                        this.FamilyIdRules();
                        this.FirstNameRules();
                        this.IsAdultRules();
                        this.LastNameRules();
                        this.PhoneRules();
                        this.SmsRemindersEnabledRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentRequestModel model)
                {
                        this.BirthdayRules();
                        this.EmailRules();
                        this.EmailRemindersEnabledRules();
                        this.FamilyIdRules();
                        this.FirstNameRules();
                        this.IsAdultRules();
                        this.LastNameRules();
                        this.PhoneRules();
                        this.SmsRemindersEnabledRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>d7e8f790f0ecf8fe64d1025853a1e582</Hash>
</Codenesium>*/