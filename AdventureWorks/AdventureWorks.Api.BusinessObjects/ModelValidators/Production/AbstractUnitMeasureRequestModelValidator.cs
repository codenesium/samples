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
	public abstract class AbstractApiUnitMeasureRequestModelValidator: AbstractValidator<ApiUnitMeasureRequestModel>
	{
		public new ValidationResult Validate(ApiUnitMeasureRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitMeasureRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IUnitMeasureRepository UnitMeasureRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiUnitMeasureRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiUnitMeasureRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.UnitMeasureRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>1ebc60ecad1865f4072091852e9b2978</Hash>
</Codenesium>*/