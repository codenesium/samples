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
        public abstract class AbstractApiPostHistoryTypesRequestModelValidator : AbstractValidator<ApiPostHistoryTypesRequestModel>
        {
                private int existingRecordId;

                private IPostHistoryTypesRepository postHistoryTypesRepository;

                public AbstractApiPostHistoryTypesRequestModelValidator(IPostHistoryTypesRepository postHistoryTypesRepository)
                {
                        this.postHistoryTypesRepository = postHistoryTypesRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPostHistoryTypesRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void TypeRules()
                {
                        this.RuleFor(x => x.Type).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>9ae5422cecae47fec1de307e6186738f</Hash>
</Codenesium>*/