using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiStudentRequestModelValidator : AbstractApiStudentRequestModelValidator, IApiStudentRequestModelValidator
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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ff611db77aee9252d0ec4155ab51c2c6</Hash>
</Codenesium>*/