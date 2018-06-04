using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiUnitMeasureRequestModelValidator: AbstractValidator<ApiUnitMeasureRequestModel>
	{
		private string existingRecordId;

		public new ValidationResult Validate(ApiUnitMeasureRequestModel model, string id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitMeasureRequestModel model, string id)
		{
			this.existingRecordId = id;
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
			UnitMeasure record = await this.UnitMeasureRepository.GetName(model.Name);

			if(record == null || record.UnitMeasureCode == this.existingRecordId)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>0f3ec1020ff7f7389fbe934d722fb98b</Hash>
</Codenesium>*/