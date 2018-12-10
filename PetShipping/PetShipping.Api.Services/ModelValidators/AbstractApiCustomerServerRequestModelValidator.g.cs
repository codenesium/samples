using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCustomerServerRequestModelValidator : AbstractValidator<ApiCustomerServerRequestModel>
	{
		private int existingRecordId;

		protected ICustomerRepository CustomerRepository { get; private set; }

		public AbstractApiCustomerServerRequestModelValidator(ICustomerRepository customerRepository)
		{
			this.CustomerRepository = customerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Email).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FirstName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LastName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Phone).Length(0, 10).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>5c6ce3c69b222dd1201a9deb51187b37</Hash>
</Codenesium>*/