using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiScrapReasonRequestModelValidator: AbstractValidator<ApiScrapReasonRequestModel>
	{
		public new ValidationResult Validate(ApiScrapReasonRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiScrapReasonRequestModel model)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiScrapReasonRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiScrapReasonRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.ScrapReasonRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>78d8720debd6e32d8e67c41bbbfed4bd</Hash>
</Codenesium>*/