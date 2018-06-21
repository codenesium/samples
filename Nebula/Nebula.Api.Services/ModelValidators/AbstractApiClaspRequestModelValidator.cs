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
        public abstract class AbstractApiClaspRequestModelValidator : AbstractValidator<ApiClaspRequestModel>
        {
                private int existingRecordId;

                private IClaspRepository claspRepository;

                public AbstractApiClaspRequestModelValidator(IClaspRepository claspRepository)
                {
                        this.claspRepository = claspRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiClaspRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NextChainIdRules()
                {
                        this.RuleFor(x => x.NextChainId).MustAsync(this.BeValidChain).When(x => x?.NextChainId != null).WithMessage("Invalid reference");
                }

                public virtual void PreviousChainIdRules()
                {
                        this.RuleFor(x => x.PreviousChainId).MustAsync(this.BeValidChain).When(x => x?.PreviousChainId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidChain(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.claspRepository.GetChain(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>3cb5f972c15051eed4b95b12850c3260</Hash>
</Codenesium>*/