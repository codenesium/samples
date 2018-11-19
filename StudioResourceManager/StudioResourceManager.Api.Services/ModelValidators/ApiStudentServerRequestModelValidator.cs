using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>01789faf38256042e4ead1f28b3e4701</Hash>
</Codenesium>*/