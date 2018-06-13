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
        public abstract class AbstractApiProductDocumentRequestModelValidator: AbstractValidator<ApiProductDocumentRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductDocumentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductDocumentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DocumentNodeRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>dbadb2db49d4b29f15737519f72b2c8e</Hash>
</Codenesium>*/