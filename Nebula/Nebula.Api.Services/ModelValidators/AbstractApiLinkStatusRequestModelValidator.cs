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
        public abstract class AbstractApiLinkStatusRequestModelValidator : AbstractValidator<ApiLinkStatusRequestModel>
        {
                private int existingRecordId;

                private ILinkStatusRepository linkStatusRepository;

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
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>46c89bb59636911ecee9d5fe093ed2c9</Hash>
</Codenesium>*/