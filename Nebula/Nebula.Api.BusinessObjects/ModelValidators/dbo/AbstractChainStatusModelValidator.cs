using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>594e5acec2b28221ffe304f0d358734e</Hash>
</Codenesium>*/