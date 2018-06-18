using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractApiCustomerRequestModelValidator: AbstractValidator<ApiCustomerRequestModel>
        {
                private int existingRecordId;

                ICustomerRepository customerRepository;

                public AbstractApiCustomerRequestModelValidator(ICustomerRepository customerRepository)
                {
                        this.customerRepository = customerRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiCustomerRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void EmailRules()
                {
                        this.RuleFor(x => x.Email).NotNull();
                        this.RuleFor(x => x.Email).Length(0, 128);
                }

                public virtual void FirstNameRules()
                {
                        this.RuleFor(x => x.FirstName).NotNull();
                        this.RuleFor(x => x.FirstName).Length(0, 128);
                }

                public virtual void LastNameRules()
                {
                        this.RuleFor(x => x.LastName).NotNull();
                        this.RuleFor(x => x.LastName).Length(0, 128);
                }

                public virtual void PhoneRules()
                {
                        this.RuleFor(x => x.Phone).NotNull();
                        this.RuleFor(x => x.Phone).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>2948d69082ef3b5567fc82e93bb49988</Hash>
</Codenesium>*/