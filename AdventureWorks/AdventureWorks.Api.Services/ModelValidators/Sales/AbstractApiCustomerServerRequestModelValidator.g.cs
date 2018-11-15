using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCustomerServerRequestModelValidator : AbstractValidator<ApiCustomerServerRequestModel>
	{
		private int existingRecordId;

		private ICustomerRepository customerRepository;

		public AbstractApiCustomerServerRequestModelValidator(ICustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByAccountNumber).When(x => !x?.AccountNumber.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCustomerServerRequestModel.AccountNumber));
			this.RuleFor(x => x.AccountNumber).Length(0, 10);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void PersonIDRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCustomerServerRequestModel.Rowguid));
		}

		public virtual void StoreIDRules()
		{
			this.RuleFor(x => x.StoreID).MustAsync(this.BeValidStoreByStoreID).When(x => !x?.StoreID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritoryByTerritoryID).When(x => !x?.TerritoryID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidStoreByStoreID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.customerRepository.StoreByStoreID(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidSalesTerritoryByTerritoryID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.customerRepository.SalesTerritoryByTerritoryID(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeUniqueByAccountNumber(ApiCustomerServerRequestModel model,  CancellationToken cancellationToken)
		{
			Customer record = await this.customerRepository.ByAccountNumber(model.AccountNumber);

			if (record == null || (this.existingRecordId != default(int) && record.CustomerID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByRowguid(ApiCustomerServerRequestModel model,  CancellationToken cancellationToken)
		{
			Customer record = await this.customerRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.CustomerID == this.existingRecordId))
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
    <Hash>70df5a6a5412ec2088e14557b6618c22</Hash>
</Codenesium>*/