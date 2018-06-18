using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractApiOrganizationRequestModelValidator: AbstractValidator<ApiOrganizationRequestModel>
        {
                private int existingRecordId;

                IOrganizationRepository organizationRepository;

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
    <Hash>c7c1eede6fb58aedc8d8f1cd74a3e68a</Hash>
</Codenesium>*/