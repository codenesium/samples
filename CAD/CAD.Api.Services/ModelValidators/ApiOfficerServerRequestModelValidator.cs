using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOfficerServerRequestModelValidator : AbstractApiOfficerServerRequestModelValidator, IApiOfficerServerRequestModelValidator
	{
		public ApiOfficerServerRequestModelValidator(IOfficerRepository officerRepository)
			: base(officerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOfficerServerRequestModel model)
		{
			this.BadgeRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PasswordRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerServerRequestModel model)
		{
			this.BadgeRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PasswordRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>66a50efd2cdedb4f8790fe12b7fa31bf</Hash>
</Codenesium>*/