using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects

{
	public abstract class AbstractStateModelValidator: AbstractValidator<StateModel>
	{
		public new ValidationResult Validate(StateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(StateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 2);
		}
	}
}

/*<Codenesium>
    <Hash>7e27716e02e0b341d153002712b9672e</Hash>
</Codenesium>*/