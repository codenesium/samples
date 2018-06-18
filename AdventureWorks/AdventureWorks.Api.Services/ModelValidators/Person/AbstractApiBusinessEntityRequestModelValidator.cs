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
        public abstract class AbstractApiBusinessEntityRequestModelValidator: AbstractValidator<ApiBusinessEntityRequestModel>
        {
                private int existingRecordId;

                IBusinessEntityRepository businessEntityRepository;

                public AbstractApiBusinessEntityRequestModelValidator(IBusinessEntityRepository businessEntityRepository)
                {
                        this.businessEntityRepository = businessEntityRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void RowguidRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>37029adcbcfe73cac7ef5705db91c6bf</Hash>
</Codenesium>*/