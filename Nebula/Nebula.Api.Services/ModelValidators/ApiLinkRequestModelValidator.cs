using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public class ApiLinkRequestModelValidator : AbstractApiLinkRequestModelValidator, IApiLinkRequestModelValidator
        {
                public ApiLinkRequestModelValidator(ILinkRepository linkRepository)
                        : base(linkRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLinkRequestModel model)
                {
                        this.AssignedMachineIdRules();
                        this.ChainIdRules();
                        this.DateCompletedRules();
                        this.DateStartedRules();
                        this.DynamicParametersRules();
                        this.ExternalIdRules();
                        this.LinkStatusIdRules();
                        this.NameRules();
                        this.OrderRules();
                        this.ResponseRules();
                        this.StaticParametersRules();
                        this.TimeoutInSecondsRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkRequestModel model)
                {
                        this.AssignedMachineIdRules();
                        this.ChainIdRules();
                        this.DateCompletedRules();
                        this.DateStartedRules();
                        this.DynamicParametersRules();
                        this.ExternalIdRules();
                        this.LinkStatusIdRules();
                        this.NameRules();
                        this.OrderRules();
                        this.ResponseRules();
                        this.StaticParametersRules();
                        this.TimeoutInSecondsRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>de2ba1fd8873fb6abdcb6f9fc3922ca7</Hash>
</Codenesium>*/