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
	public abstract class AbstractApiSaleRequestModelValidator: AbstractValidator<ApiSaleRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiSaleRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IPaymentTypeRepository PaymentTypeRepository { get; set; }
		public IPetRepository PetRepository { get; set; }
		public virtual void AmountRules()
		{
			this.RuleFor(x => x.Amount).NotNull();
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
			this.RuleFor(x => x.PaymentTypeId).NotNull();
			this.RuleFor(x => x.PaymentTypeId).MustAsync(this.BeValidPaymentType).When(x => x ?.PaymentTypeId != null).WithMessage("Invalid reference");
		}

		public virtual void PetIdRules()
		{
			this.RuleFor(x => x.PetId).NotNull();
			this.RuleFor(x => x.PetId).MustAsync(this.BeValidPet).When(x => x ?.PetId != null).WithMessage("Invalid reference");
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull();
			this.RuleFor(x => x.Phone).Length(0, 10);
		}

		private async Task<bool> BeValidPaymentType(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PaymentTypeRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidPet(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PetRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d9a0018a61d7764fefd87151edfdc310</Hash>
</Codenesium>*/