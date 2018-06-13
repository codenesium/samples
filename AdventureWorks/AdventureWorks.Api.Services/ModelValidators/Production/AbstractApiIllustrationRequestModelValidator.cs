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
        public abstract class AbstractApiIllustrationRequestModelValidator: AbstractValidator<ApiIllustrationRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiIllustrationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiIllustrationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DiagramRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>e64f521e5072d7639ea0383a095977e1</Hash>
</Codenesium>*/