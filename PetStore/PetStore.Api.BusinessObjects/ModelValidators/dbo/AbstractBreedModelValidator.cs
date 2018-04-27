using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects

{
	public abstract class AbstractBreedModelValidator: AbstractValidator<BreedModel>
	{
		public new ValidationResult Validate(BreedModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(BreedModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>d2e4f42235148fc77af797047f402863</Hash>
</Codenesium>*/