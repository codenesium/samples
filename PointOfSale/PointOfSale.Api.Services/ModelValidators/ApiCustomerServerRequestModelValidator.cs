using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class ApiCustomerServerRequestModelValidator : AbstractValidator<ApiCustomerServerRequestModel>, IApiCustomerServerRequestModelValidator
	{
		private int existingRecordId;

		protected ICustomerRepository CustomerRepository { get; private set; }

		public ApiCustomerServerRequestModelValidator(ICustomerRepository customerRepository)
		{
			this.CustomerRepository = customerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCustomerServerRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerServerRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Phone).Length(0, 15).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>ed17369365df43df7ab243e9e42589ef</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/