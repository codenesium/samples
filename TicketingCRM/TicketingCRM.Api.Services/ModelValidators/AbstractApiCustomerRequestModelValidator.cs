using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractApiCustomerRequestModelValidator : AbstractValidator<ApiCustomerRequestModel>
        {
                private int existingRecordId;

                private ICustomerRepository customerRepository;

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
    <Hash>6b0bf5b086e780e099760cef781eb418</Hash>
</Codenesium>*/