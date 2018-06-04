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
	public abstract class AbstractApiCountryRegionRequestModelValidator: AbstractValidator<ApiCountryRegionRequestModel>
	{
		private string existingRecordId;

		public new ValidationResult Validate(ApiCountryRegionRequestModel model, string id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRegionRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public ICountryRegionRepository CountryRegionRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCountryRegionRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiCountryRegionRequestModel model,  CancellationToken cancellationToken)
		{
			CountryRegion record = await this.CountryRegionRepository.GetName(model.Name);

			if(record == null || record.CountryRegionCode == this.existingRecordId)
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
    <Hash>3bccb412f4af647330239998c3ea7235</Hash>
</Codenesium>*/