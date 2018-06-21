using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractApiTeamRequestModelValidator : AbstractValidator<ApiTeamRequestModel>
        {
                private int existingRecordId;

                private ITeamRepository teamRepository;

                public AbstractApiTeamRequestModelValidator(ITeamRepository teamRepository)
                {
                        this.teamRepository = teamRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTeamRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void OrganizationIdRules()
                {
                        this.RuleFor(x => x.OrganizationId).MustAsync(this.BeValidOrganization).When(x => x?.OrganizationId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidOrganization(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.teamRepository.GetOrganization(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>b6f63fca1a608c3ea07f22ebf27077df</Hash>
</Codenesium>*/