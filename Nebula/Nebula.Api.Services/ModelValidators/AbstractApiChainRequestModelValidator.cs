using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractApiChainRequestModelValidator: AbstractValidator<ApiChainRequestModel>
        {
                private int existingRecordId;

                IChainRepository chainRepository;

                public AbstractApiChainRequestModelValidator(IChainRepository chainRepository)
                {
                        this.chainRepository = chainRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiChainRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ChainStatusIdRules()
                {
                        this.RuleFor(x => x.ChainStatusId).MustAsync(this.BeValidChainStatus).When(x => x ?.ChainStatusId != null).WithMessage("Invalid reference");
                }

                public virtual void ExternalIdRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void TeamIdRules()
                {
                        this.RuleFor(x => x.TeamId).MustAsync(this.BeValidTeam).When(x => x ?.TeamId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidChainStatus(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.chainRepository.GetChainStatus(id);

                        return record != null;
                }

                private async Task<bool> BeValidTeam(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.chainRepository.GetTeam(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>bb03d2635d98fb27dbc6f66f7616cdf7</Hash>
</Codenesium>*/