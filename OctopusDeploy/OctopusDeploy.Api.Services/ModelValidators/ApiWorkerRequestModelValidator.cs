using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiWorkerRequestModelValidator: AbstractApiWorkerRequestModelValidator, IApiWorkerRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>141e0ef695336535c74e8c92dabe78ea</Hash>
</Codenesium>*/