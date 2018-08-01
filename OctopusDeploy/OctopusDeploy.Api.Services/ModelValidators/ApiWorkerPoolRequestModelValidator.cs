using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiWorkerPoolRequestModelValidator : AbstractApiWorkerPoolRequestModelValidator, IApiWorkerPoolRequestModelValidator
	{
		public ApiWorkerPoolRequestModelValidator(IWorkerPoolRepository workerPoolRepository)
			: base(workerPoolRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiWorkerPoolRequestModel model)
		{
			this.IsDefaultRules();
			this.JSONRules();
			this.NameRules();
			this.SortOrderRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerPoolRequestModel model)
		{
			this.IsDefaultRules();
			this.JSONRules();
			this.NameRules();
			this.SortOrderRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4f08ace2ce82842fb512cf60757fc38b</Hash>
</Codenesium>*/