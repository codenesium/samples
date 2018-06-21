using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractApiOrganizationRequestModelValidator : AbstractValidator<ApiOrganizationRequestModel>
        {
                private int existingRecordId;

                private IOrganizationRepository organizationRepository;

                public AbstractApiOrganizationRequestModelValidator(IOrganizationRepository organizationRepository)
                {
                        this.organizationRepository = organizationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiOrganizationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>fd9452b26518cd1aa4fba7d78eda8d3f</Hash>
</Codenesium>*/