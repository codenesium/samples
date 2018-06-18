using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractApiPenRequestModelValidator: AbstractValidator<ApiPenRequestModel>
        {
                private int existingRecordId;

                IPenRepository penRepository;

                public AbstractApiPenRequestModelValidator(IPenRepository penRepository)
                {
                        this.penRepository = penRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPenRequestModel model, int id)
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
    <Hash>6bf724b1637b46e149b16166bfc64692</Hash>
</Codenesium>*/