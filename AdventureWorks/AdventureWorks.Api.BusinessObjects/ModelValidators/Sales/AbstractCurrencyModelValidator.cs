using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiCurrencyModelValidator: AbstractValidator<ApiCurrencyModel>
	{
		public new ValidationResult Validate(ApiCurrencyModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCurrencyModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICurrencyRepository CurrencyRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private bool BeUniqueGetName(ApiCurrencyModel model)
		{
			return this.CurrencyRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>2fb0bf5ebdd146f6894e60c9aad99f34</Hash>
</Codenesium>*/