using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects

{
	public abstract class AbstractSaleModelValidator: AbstractValidator<SaleModel>
	{
		public new ValidationResult Validate(SaleModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SaleModel model)
		{
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
			this.RuleFor(x => x.PaymentTypeId).Must(this.BeValidPaymentType).When(x => x ?.PaymentTypeId != null).WithMessage("Invalid reference");
		}

		public virtual void PetIdRules()
		{
			this.RuleFor(x => x.PetId).NotNull();
			this.RuleFor(x => x.PetId).Must(this.BeValidPet).When(x => x ?.PetId != null).WithMessage("Invalid reference");
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull();
			this.RuleFor(x => x.Phone).Length(0, 10);
		}

		private bool BeValidPaymentType(int id)
		{
			return this.PaymentTypeRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidPet(int id)
		{
			return this.PetRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>adb7ca7b54df097860886ba288955dfe</Hash>
</Codenesium>*/