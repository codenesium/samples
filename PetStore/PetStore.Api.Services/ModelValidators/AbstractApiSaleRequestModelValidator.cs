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
	public abstract class AbstractApiSaleRequestModelValidator : AbstractValidator<ApiSaleRequestModel>
	{
		private int existingRecordId;

		private ISaleRepository saleRepository;

		public AbstractApiSaleRequestModelValidator(ISaleRepository saleRepository)
		{
			this.saleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AmountRules()
		{
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 90);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 90);
		}

		public virtual void PaymentTypeIdRules()
		{
			this.RuleFor(x => x.PaymentTypeId).MustAsync(this.BeValidPaymentTypeByPaymentTypeId).When(x => x?.PaymentTypeId != null).WithMessage("Invalid reference");
		}

		public virtual void PetIdRules()
		{
			this.RuleFor(x => x.PetId).MustAsync(this.BeValidPetByPetId).When(x => x?.PetId != null).WithMessage("Invalid reference");
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull();
			this.RuleFor(x => x.Phone).Length(0, 10);
		}

		private async Task<bool> BeValidPaymentTypeByPaymentTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.saleRepository.PaymentTypeByPaymentTypeId(id);

			return record != null;
		}

		private async Task<bool> BeValidPetByPetId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.saleRepository.PetByPetId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d7c64ccbd653b0785c0e9c623a7b9a58</Hash>
</Codenesium>*/