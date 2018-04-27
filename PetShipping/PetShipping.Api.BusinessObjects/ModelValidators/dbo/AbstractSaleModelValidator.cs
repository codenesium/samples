using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

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

		public IClientRepository ClientRepository { get; set; }
		public IPetRepository PetRepository { get; set; }
		public virtual void AmountRules()
		{
			this.RuleFor(x => x.Amount).NotNull();
		}

		public virtual void ClientIdRules()
		{
			this.RuleFor(x => x.ClientId).NotNull();
			this.RuleFor(x => x.ClientId).Must(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void PetIdRules()
		{
			this.RuleFor(x => x.PetId).NotNull();
			this.RuleFor(x => x.PetId).Must(this.BeValidPet).When(x => x ?.PetId != null).WithMessage("Invalid reference");
		}

		public virtual void SaleDateRules()
		{
			this.RuleFor(x => x.SaleDate).NotNull();
		}

		public virtual void SalesPersonIdRules()
		{
			this.RuleFor(x => x.SalesPersonId).NotNull();
		}

		private bool BeValidClient(int id)
		{
			return this.ClientRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidPet(int id)
		{
			return this.PetRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>8b501d3c1b5d1e382d9efcda51d88835</Hash>
</Codenesium>*/