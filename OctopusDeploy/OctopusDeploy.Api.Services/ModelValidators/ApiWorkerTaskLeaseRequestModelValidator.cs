using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiWorkerTaskLeaseRequestModelValidator : AbstractApiWorkerTaskLeaseRequestModelValidator, IApiWorkerTaskLeaseRequestModelValidator
	{
		public ApiWorkerTaskLeaseRequestModelValidator(IWorkerTaskLeaseRepository workerTaskLeaseRepository)
			: base(workerTaskLeaseRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiWorkerTaskLeaseRequestModel model)
		{
			this.ExclusiveRules();
			this.JSONRules();
			this.NameRules();
			this.TaskIdRules();
			this.WorkerIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerTaskLeaseRequestModel model)
		{
			this.ExclusiveRules();
			this.JSONRules();
			this.NameRules();
			this.TaskIdRules();
			this.WorkerIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>deea0f5508e862fa6ab4d7b5e3381155</Hash>
</Codenesium>*/