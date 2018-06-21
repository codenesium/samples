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
        public abstract class AbstractApiUserRoleRequestModelValidator : AbstractValidator<ApiUserRoleRequestModel>
        {
                private string existingRecordId;

                private IUserRoleRepository userRoleRepository;

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiUserRoleRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetName(ApiUserRoleRequestModel model,  CancellationToken cancellationToken)
                {
                        UserRole record = await this.userRoleRepository.GetName(model.Name);

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
    <Hash>68630b16b789f6cb117b1d7405a85952</Hash>
</Codenesium>*/