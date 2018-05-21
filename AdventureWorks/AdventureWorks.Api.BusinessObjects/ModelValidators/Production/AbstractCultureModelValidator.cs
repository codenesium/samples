using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiCultureModelValidator: AbstractValidator<ApiCultureModel>
	{
		public new ValidationResult Validate(ApiCultureModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCultureModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICultureRepository CultureRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCultureModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private bool BeUniqueGetName(ApiCultureModel model)
		{
			return this.CultureRepository.GetName(model.Name) == null;
		}
	}
}

/*<Codenesium>
    <Hash>c3571dd5f8743deb0a36c93b1b94d143</Hash>
</Codenesium>*/