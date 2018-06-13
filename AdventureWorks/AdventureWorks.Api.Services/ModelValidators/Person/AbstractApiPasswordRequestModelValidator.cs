using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiPasswordRequestModelValidator: AbstractValidator<ApiPasswordRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiPasswordRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiPasswordRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void PasswordHashRules()
                {
                        this.RuleFor(x => x.PasswordHash).NotNull();
                        this.RuleFor(x => x.PasswordHash).Length(0, 128);
                }

                public virtual void PasswordSaltRules()
                {
                        this.RuleFor(x => x.PasswordSalt).NotNull();
                        this.RuleFor(x => x.PasswordSalt).Length(0, 10);
                }

                public virtual void RowguidRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2a6db9a4ac191f3565b10898cc495f16</Hash>
</Codenesium>*/