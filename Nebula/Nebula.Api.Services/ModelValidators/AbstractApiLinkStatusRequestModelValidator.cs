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
        public abstract class AbstractApiLinkStatusRequestModelValidator: AbstractValidator<ApiLinkStatusRequestModel>
        {
                private int existingRecordId;

                ILinkStatusRepository linkStatusRepository;

                public AbstractApiLinkStatusRequestModelValidator(ILinkStatusRepository linkStatusRepository)
                {
                        this.linkStatusRepository = linkStatusRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiLinkStatusRequestModel model, int id)
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
    <Hash>fcbe335354dfdd18e40fcc69c5dc5b81</Hash>
</Codenesium>*/