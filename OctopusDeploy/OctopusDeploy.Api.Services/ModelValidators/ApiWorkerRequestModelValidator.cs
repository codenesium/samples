using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiWorkerRequestModelValidator : AbstractApiWorkerRequestModelValidator, IApiWorkerRequestModelValidator
	{
		public ApiWorkerRequestModelValidator(IWorkerRepository workerRepository)
			: base(workerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiWorkerRequestModel model)
		{
			this.CommunicationStyleRules();
			this.FingerprintRules();
			this.IsDisabledRules();
			this.JSONRules();
			this.MachinePolicyIdRules();
			this.NameRules();
			this.RelatedDocumentIdsRules();
			this.ThumbprintRules();
			this.WorkerPoolIdsRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerRequestModel model)
		{
			this.CommunicationStyleRules();
			this.FingerprintRules();
			this.IsDisabledRules();
			this.JSONRules();
			this.MachinePolicyIdRules();
			this.NameRules();
			this.RelatedDocumentIdsRules();
			this.ThumbprintRules();
			this.WorkerPoolIdsRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ce861bcdfcc88ef0bb004f2e0c2ed698</Hash>
</Codenesium>*/