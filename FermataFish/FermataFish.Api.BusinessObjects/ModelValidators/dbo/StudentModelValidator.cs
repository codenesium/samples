using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiStudentRequestModelValidator: AbstractApiStudentRequestModelValidator, IApiStudentRequestModelValidator
	{
		public ApiStudentRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c42a86dd03f51b152c0a820ea45e4e4b</Hash>
</Codenesium>*/