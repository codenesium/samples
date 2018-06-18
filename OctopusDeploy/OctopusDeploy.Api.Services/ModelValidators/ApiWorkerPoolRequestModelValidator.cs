using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiWorkerPoolRequestModelValidator: AbstractApiWorkerPoolRequestModelValidator, IApiWorkerPoolRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>ee1f601653d90feac9b313feb0b2867a</Hash>
</Codenesium>*/