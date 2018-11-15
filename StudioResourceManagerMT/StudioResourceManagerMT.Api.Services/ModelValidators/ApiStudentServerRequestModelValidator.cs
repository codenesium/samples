using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiStudentServerRequestModelValidator : AbstractApiStudentServerRequestModelValidator, IApiStudentServerRequestModelValidator
	{
		public ApiStudentServerRequestModelValidator(IStudentRepository studentRepository)
			: base(studentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudentServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentServerRequestModel model)
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
    <Hash>a770bee5d4b39785fb5b79187f296fa2</Hash>
</Codenesium>*/