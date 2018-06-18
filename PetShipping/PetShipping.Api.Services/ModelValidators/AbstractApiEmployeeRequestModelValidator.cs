using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiEmployeeRequestModelValidator: AbstractValidator<ApiEmployeeRequestModel>
        {
                private int existingRecordId;

                IEmployeeRepository employeeRepository;

                public AbstractApiEmployeeRequestModelValidator(IEmployeeRepository employeeRepository)
                {
                        this.employeeRepository = employeeRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiEmployeeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void FirstNameRules()
                {
                        this.RuleFor(x => x.FirstName).NotNull();
                        this.RuleFor(x => x.FirstName).Length(0, 128);
                }

                public virtual void IsSalesPersonRules()
                {
                }

                public virtual void IsShipperRules()
                {
                }

                public virtual void LastNameRules()
                {
                        this.RuleFor(x => x.LastName).NotNull();
                        this.RuleFor(x => x.LastName).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>68dc5dc88839a5d539bd703fd169f3b9</Hash>
</Codenesium>*/