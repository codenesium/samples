using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiWorkerTaskLeaseRequestModelValidator: AbstractApiWorkerTaskLeaseRequestModelValidator, IApiWorkerTaskLeaseRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>0e79d4b6b0a70a962a3f163fbf63f2c2</Hash>
</Codenesium>*/