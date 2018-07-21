using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractApiChainStatusRequestModelValidator : AbstractValidator<ApiChainStatusRequestModel>
        {
                private int existingRecordId;

                private IChainStatusRepository chainStatusRepository;

                public AbstractApiChainStatusRequestModelValidator(IChainStatusRepository chainStatusRepository)
                {
                        this.chainStatusRepository = chainStatusRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiChainStatusRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>82c618217f2dfb5894d19b7e2a2ca40d</Hash>
</Codenesium>*/