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

                IBusinessEntityContactRepository businessEntityContactRepository;

                public AbstractApiBusinessEntityContactRequestModelValidator(IBusinessEntityContactRepository businessEntityContactRepository)
                {
                        this.businessEntityContactRepository = businessEntityContactRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityContactRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ContactTypeIDRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void PersonIDRules()
                {
                }

                public virtual void RowguidRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c1dc4403465145a8792537ef3d6484bc</Hash>
</Codenesium>*/