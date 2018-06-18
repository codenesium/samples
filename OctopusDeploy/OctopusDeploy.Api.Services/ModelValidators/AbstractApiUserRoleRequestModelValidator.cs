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
        public abstract class AbstractApiUserRoleRequestModelValidator: AbstractValidator<ApiUserRoleRequestModel>
        {
                private string existingRecordId;

                IUserRoleRepository userRoleRepository;

                public AbstractApiUserRoleRequestModelValidator(IUserRoleRepository userRoleRepository)
                {
                        this.userRoleRepository = userRoleRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiUserRoleRequestModel model, string id)
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiUserRoleRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetName(ApiUserRoleRequestModel model,  CancellationToken cancellationToken)
                {
                        UserRole record = await this.userRoleRepository.GetName(model.Name);

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
    <Hash>82d9a03a79c123f6da585a7534e0abc4</Hash>
</Codenesium>*/