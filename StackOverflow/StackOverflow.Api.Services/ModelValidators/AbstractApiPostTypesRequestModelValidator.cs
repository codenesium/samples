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
                        this.RuleFor(x => x.Type).NotNull();
                        this.RuleFor(x => x.Type).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>69ea0e5bc4786820680bd7115589b115</Hash>
</Codenesium>*/