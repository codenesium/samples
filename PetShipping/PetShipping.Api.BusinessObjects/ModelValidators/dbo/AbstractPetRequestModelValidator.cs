using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiPetRequestModelValidator: AbstractValidator<ApiPetRequestModel>
	{
		public new ValidationResult Validate(ApiPetRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPetRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IBreedRepository BreedRepository { get; set; }
		public IClientRepository ClientRepository { get; set; }
		public virtual void BreedIdRules()
		{
			this.RuleFor(x => x.BreedId).NotNull();
			this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreed).When(x => x ?.BreedId != null).WithMessage("Invalid reference");
		}

		public virtual void ClientIdRules()
		{
			this.RuleFor(x => x.ClientId).NotNull();
			this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
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

		private async Task<bool> BeValidBreed(int id,  CancellationToken cancellationToken)
		{
			var record = await this.BreedRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidClient(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ClientRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b142298fa2390adee0fd6881bce33001</Hash>
</Codenesium>*/