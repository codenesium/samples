using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiWorkerTaskLeaseRequestModelValidator: AbstractApiWorkerTaskLeaseRequestModelValidator, IApiWorkerTaskLeaseRequestModelValidator
        {
                public ApiWorkerTaskLeaseRequestModelValidator()
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>2e7b5f08f7f3272e1d0f3b84bcc2a3f5</Hash>
</Codenesium>*/