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
	public abstract class AbstractApiCurrencyRequestModelValidator: AbstractValidator<ApiCurrencyRequestModel>
	{
		private string existingRecordId;

		public new ValidationResult Validate(ApiCurrencyRequestModel model, string id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCurrencyRequestModel model, string id)
		{
			this.existingRecordId = id;
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiCurrencyRequestModel model,  CancellationToken cancellationToken)
		{
			Currency record = await this.CurrencyRepository.GetName(model.Name);

			if(record == null || record.CurrencyCode == this.existingRecordId)
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
    <Hash>5f034a81c15d0b040f2e4aa31cd76204</Hash>
</Codenesium>*/