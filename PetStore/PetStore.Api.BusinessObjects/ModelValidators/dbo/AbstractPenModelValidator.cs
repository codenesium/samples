using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects

{
	public abstract class AbstractPenModelValidator: AbstractValidator<PenModel>
	{
		public new ValidationResult Validate(PenModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PenModel model)
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
    <Hash>0b17f6bc12f7551f4bca56f7f0bc5315</Hash>
</Codenesium>*/