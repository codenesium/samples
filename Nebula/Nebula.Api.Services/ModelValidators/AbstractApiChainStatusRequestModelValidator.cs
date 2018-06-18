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
        public abstract class AbstractApiChainStatusRequestModelValidator: AbstractValidator<ApiChainStatusRequestModel>
        {
                private int existingRecordId;

                IChainStatusRepository chainStatusRepository;

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
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>82427b32cc7f9d056fc83d42e010f76a</Hash>
</Codenesium>*/