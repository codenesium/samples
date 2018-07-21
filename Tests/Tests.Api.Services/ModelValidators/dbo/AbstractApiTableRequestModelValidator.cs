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
        public abstract class AbstractApiTableRequestModelValidator : AbstractValidator<ApiTableRequestModel>
        {
                private int existingRecordId;

                private ITableRepository tableRepository;

                public AbstractApiTableRequestModelValidator(ITableRepository tableRepository)
                {
                        this.tableRepository = tableRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTableRequestModel model, int id)
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
    <Hash>30c09e064a0b97755a9d2ec84d82c69a</Hash>
</Codenesium>*/