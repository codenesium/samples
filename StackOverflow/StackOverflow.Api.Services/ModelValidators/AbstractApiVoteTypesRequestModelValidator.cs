using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractApiVoteTypesRequestModelValidator : AbstractValidator<ApiVoteTypesRequestModel>
        {
                private int existingRecordId;

                private IVoteTypesRepository voteTypesRepository;

                public AbstractApiVoteTypesRequestModelValidator(IVoteTypesRepository voteTypesRepository)
                {
                        this.voteTypesRepository = voteTypesRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiVoteTypesRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>30402660163aab5c7274adb45af3c9e3</Hash>
</Codenesium>*/