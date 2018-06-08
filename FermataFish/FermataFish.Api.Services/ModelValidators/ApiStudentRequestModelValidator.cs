using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiStudentRequestModelValidator: AbstractApiStudentRequestModelValidator, IApiStudentRequestModelValidator
        {
                public ApiStudentRequestModelValidator()
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
    <Hash>a1eb11224efa8e05484212978c8880cf</Hash>
</Codenesium>*/