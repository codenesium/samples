using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
			this.UserIdRules();
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
			this.UserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>fe090579c9b53b458d9101386dcb57ed</Hash>
</Codenesium>*/