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

                public ValidationResult Validate(ApiChainRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiChainRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IChainStatusRepository ChainStatusRepository { get; set; }

                public ITeamRepository TeamRepository { get; set; }

                public virtual void ChainStatusIdRules()
                {
                        this.RuleFor(x => x.ChainStatusId).NotNull();
                        this.RuleFor(x => x.ChainStatusId).MustAsync(this.BeValidChainStatus).When(x => x ?.ChainStatusId != null).WithMessage("Invalid reference");
                }

                public virtual void ExternalIdRules()
                {
                        this.RuleFor(x => x.ExternalId).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void TeamIdRules()
                {
                        this.RuleFor(x => x.TeamId).NotNull();
                        this.RuleFor(x => x.TeamId).MustAsync(this.BeValidTeam).When(x => x ?.TeamId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidChainStatus(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.ChainStatusRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidTeam(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.TeamRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>96e0c46ea8bcf8d355b75c861d6b8fcd</Hash>
</Codenesium>*/