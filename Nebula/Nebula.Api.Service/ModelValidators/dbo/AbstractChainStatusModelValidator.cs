using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service

{
	public abstract class AbstractChainStatusModelValidator: AbstractValidator<ChainStatusModel>
	{
		public new ValidationResult Validate(ChainStatusModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ChainStatusModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}
	}
}

/*<Codenesium>
    <Hash>c032f0dd4b705ea93d1a39ea2718afc5</Hash>
</Codenesium>*/