using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPaymentTypeServerRequestModelValidator : AbstractValidator<ApiPaymentTypeServerRequestModel>, IApiPaymentTypeServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPaymentTypeRepository PaymentTypeRepository { get; private set; }

		public ApiPaymentTypeServerRequestModelValidator(IPaymentTypeRepository paymentTypeRepository)
		{
			this.PaymentTypeRepository = paymentTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPaymentTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>61b21144c3f3316c234318f36d038f42</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/