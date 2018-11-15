using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPaymentTypeServerRequestModelValidator : AbstractValidator<ApiPaymentTypeServerRequestModel>
	{
		private int existingRecordId;

		private IPaymentTypeRepository paymentTypeRepository;

		public AbstractApiPaymentTypeServerRequestModelValidator(IPaymentTypeRepository paymentTypeRepository)
		{
			this.paymentTypeRepository = paymentTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPaymentTypeServerRequestModel model, int id)
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
    <Hash>7ed28065d4e2b3484b8d22b08c6e78f8</Hash>
</Codenesium>*/