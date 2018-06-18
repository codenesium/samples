using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiProxyRequestModelValidator: AbstractValidator<ApiProxyRequestModel>
        {
                private string existingRecordId;

                IProxyRepository proxyRepository;

                public AbstractApiProxyRequestModelValidator(IProxyRepository proxyRepository)
                {
                        this.proxyRepository = proxyRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProxyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProxyRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetName(ApiProxyRequestModel model,  CancellationToken cancellationToken)
                {
                        Proxy record = await this.proxyRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (string) && record.Id == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>9bf074afef0ca62cb9911a6a74196a90</Hash>
</Codenesium>*/