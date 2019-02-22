using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiPersonServerRequestModelValidator : AbstractApiPersonServerRequestModelValidator, IApiPersonServerRequestModelValidator
	{
		public ApiPersonServerRequestModelValidator(IPersonRepository personRepository)
			: base(personRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonServerRequestModel model)
		{
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.SsnRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonServerRequestModel model)
		{
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.SsnRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>b9dc8a3a03d4c974a8a0d23fef88d0a0</Hash>
</Codenesium>*/