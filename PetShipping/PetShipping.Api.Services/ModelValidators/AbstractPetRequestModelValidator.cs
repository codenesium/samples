using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services

{
	public abstract class AbstractApiPetRequestModelValidator: AbstractValidator<ApiPetRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiPetRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPetRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>f202170bc48ae6f4fdc97e231d8a6446</Hash>
</Codenesium>*/