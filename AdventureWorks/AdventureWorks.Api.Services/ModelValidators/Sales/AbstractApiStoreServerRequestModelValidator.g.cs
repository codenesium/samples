using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiStoreServerRequestModelValidator : AbstractValidator<ApiStoreServerRequestModel>
	{
		private int existingRecordId;

		private IStoreRepository storeRepository;

		public AbstractApiStoreServerRequestModelValidator(IStoreRepository storeRepository)
		{
			this.storeRepository = storeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiStoreServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DemographicRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiStoreServerRequestModel.Rowguid));
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).MustAsync(this.BeValidSalesPersonBySalesPersonID).When(x => !x?.SalesPersonID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesPersonBySalesPersonID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.storeRepository.SalesPersonBySalesPersonID(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeUniqueByRowguid(ApiStoreServerRequestModel model,  CancellationToken cancellationToken)
		{
			Store record = await this.storeRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
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
    <Hash>2b7d291b04fd6adbe8d96e20b6081da8</Hash>
</Codenesium>*/