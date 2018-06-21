using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiPasswordRequestModelValidator : AbstractValidator<ApiPasswordRequestModel>
        {
                private int existingRecordId;

                private IPasswordRepository passwordRepository;

                public AbstractApiPasswordRequestModelValidator(IPasswordRepository passwordRepository)
                {
                        this.passwordRepository = passwordRepository;
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
    <Hash>3df5e2de502a74458f08ca2c49a25bb8</Hash>
</Codenesium>*/