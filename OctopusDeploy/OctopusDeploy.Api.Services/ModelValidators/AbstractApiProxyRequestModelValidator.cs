using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiProxyRequestModelValidator : AbstractValidator<ApiProxyRequestModel>
        {
                private string existingRecordId;

                private IProxyRepository proxyRepository;

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiProxyRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetName(ApiProxyRequestModel model,  CancellationToken cancellationToken)
                {
                        Proxy record = await this.proxyRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>e2f91a2631ae84d3367709991ee99090</Hash>
</Codenesium>*/