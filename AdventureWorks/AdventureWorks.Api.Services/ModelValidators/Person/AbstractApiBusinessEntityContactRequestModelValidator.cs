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
        public abstract class AbstractApiBusinessEntityContactRequestModelValidator: AbstractValidator<ApiBusinessEntityContactRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiBusinessEntityContactRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityContactRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ContactTypeIDRules()
                {
                        this.RuleFor(x => x.ContactTypeID).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void PersonIDRules()
                {
                        this.RuleFor(x => x.PersonID).NotNull();
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>f0726ef02947a281e13787a5481358cb</Hash>
</Codenesium>*/