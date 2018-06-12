using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiWorkerRequestModelValidator: AbstractApiWorkerRequestModelValidator, IApiWorkerRequestModelValidator
        {
                public ApiWorkerRequestModelValidator()
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
    <Hash>da61076e950b210a15a2d5b1eb14a8a1</Hash>
</Codenesium>*/