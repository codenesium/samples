using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public abstract class AbstractApiTimestampCheckRequestModelValidator : AbstractValidator<ApiTimestampCheckRequestModel>
        {
                private int existingRecordId;

                private ITimestampCheckRepository timestampCheckRepository;

                public AbstractApiTimestampCheckRequestModelValidator(ITimestampCheckRepository timestampCheckRepository)
                {
                        this.timestampCheckRepository = timestampCheckRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTimestampCheckRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void TimestampRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>22b1df2a1f852a76920ddd51b7fa9067</Hash>
</Codenesium>*/