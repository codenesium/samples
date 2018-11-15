using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class ApiVPersonServerRequestModelValidator : AbstractApiVPersonServerRequestModelValidator, IApiVPersonServerRequestModelValidator
	{
		public ApiVPersonServerRequestModelValidator(IVPersonRepository vPersonRepository)
			: base(vPersonRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVPersonServerRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVPersonServerRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>0814d9cb05c04b6c719f6c64cc925a7a</Hash>
</Codenesium>*/