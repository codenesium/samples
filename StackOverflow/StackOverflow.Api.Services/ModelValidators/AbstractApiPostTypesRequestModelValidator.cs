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
        public abstract class AbstractApiPostTypesRequestModelValidator : AbstractValidator<ApiPostTypesRequestModel>
        {
                private int existingRecordId;

                private IPostTypesRepository postTypesRepository;

                public AbstractApiPostTypesRequestModelValidator(IPostTypesRepository postTypesRepository)
                {
                        this.postTypesRepository = postTypesRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPostTypesRequestModel model, int id)
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
    <Hash>cf515b4c0fc75264364b7540ea640619</Hash>
</Codenesium>*/