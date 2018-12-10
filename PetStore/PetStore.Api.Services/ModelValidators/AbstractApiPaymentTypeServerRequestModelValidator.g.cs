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
	public abstract class AbstractApiPaymentTypeServerRequestModelValidator : AbstractValidator<ApiPaymentTypeServerRequestModel>
	{
		private int existingRecordId;

		protected IPaymentTypeRepository PaymentTypeRepository { get; private set; }

		public AbstractApiPaymentTypeServerRequestModelValidator(IPaymentTypeRepository paymentTypeRepository)
		{
			this.PaymentTypeRepository = paymentTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPaymentTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>a56c59979a27fafb202e7a106dd9b894</Hash>
</Codenesium>*/