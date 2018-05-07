using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractPetModelValidator: AbstractValidator<PetModel>
	{
		public new ValidationResult Validate(PetModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PetModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBreedRepository BreedRepository { get; set; }
		public IClientRepository ClientRepository { get; set; }
		public virtual void BreedIdRules()
		{
			this.RuleFor(x => x.BreedId).NotNull();
			this.RuleFor(x => x.BreedId).Must(this.BeValidBreed).When(x => x ?.BreedId != null).WithMessage("Invalid reference");
		}

		public virtual void ClientIdRules()
		{
			this.RuleFor(x => x.ClientId).NotNull();
			this.RuleFor(x => x.ClientId).Must(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void WeightRules()
		{
			this.RuleFor(x => x.Weight).NotNull();
		}

		private bool BeValidBreed(int id)
		{
			return this.BreedRepository.Get(id) != null;
		}

		private bool BeValidClient(int id)
		{
			return this.ClientRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>71b824657749fe3ad388d1793ba2f7cb</Hash>
</Codenesium>*/