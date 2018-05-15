using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiScrapReasonModelValidator: AbstractValidator<ApiScrapReasonModel>
	{
		public new ValidationResult Validate(ApiScrapReasonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiScrapReasonModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IScrapReasonRepository ScrapReasonRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).Must(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint");
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private bool BeUniqueGetName(ApiScrapReasonModel model)
		{
			return this.ScrapReasonRepository.GetName(model.Name) != null;
		}
	}
}

/*<Codenesium>
    <Hash>aad08be31413e9f3564468aeb12bbbba</Hash>
</Codenesium>*/