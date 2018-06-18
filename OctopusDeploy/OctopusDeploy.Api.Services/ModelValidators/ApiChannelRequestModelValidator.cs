using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiChannelRequestModelValidator: AbstractApiChannelRequestModelValidator, IApiChannelRequestModelValidator
        {
                public ApiChannelRequestModelValidator(IChannelRepository channelRepository)
                        : base(channelRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiChannelRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.LifecycleIdRules();
                        this.NameRules();
                        this.ProjectIdRules();
                        this.TenantTagsRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiChannelRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.LifecycleIdRules();
                        this.NameRules();
                        this.ProjectIdRules();
                        this.TenantTagsRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>747f85bfd4931041cf100d43280d0a6f</Hash>
</Codenesium>*/