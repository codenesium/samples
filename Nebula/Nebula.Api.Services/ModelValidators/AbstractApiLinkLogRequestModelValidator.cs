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
        public abstract class AbstractApiLinkLogRequestModelValidator: AbstractValidator<ApiLinkLogRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiLinkLogRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiLinkLogRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ILinkRepository LinkRepository { get; set; }

                public virtual void DateEnteredRules()
                {
                }

                public virtual void LinkIdRules()
                {
                        this.RuleFor(x => x.LinkId).MustAsync(this.BeValidLink).When(x => x ?.LinkId != null).WithMessage("Invalid reference");
                }

                public virtual void LogRules()
                {
                        this.RuleFor(x => x.Log).NotNull();
                        this.RuleFor(x => x.Log).Length(0, 2147483647);
                }

                private async Task<bool> BeValidLink(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.LinkRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>2b2fb5a3e057743708bbf857ea014ab1</Hash>
</Codenesium>*/