using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCustomerRequestModelValidator : AbstractValidator<ApiCustomerRequestModel>
	{
		private int existingRecordId;

		private ICustomerRepository customerRepository;

		public AbstractApiCustomerRequestModelValidator(ICustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByAccountNumber).When(x => x?.AccountNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCustomerRequestModel.AccountNumber));
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
		}

		public virtual void StoreIDRules()
		{
			this.RuleFor(x => x.StoreID).MustAsync(this.BeValidStoreByStoreID).When(x => x?.StoreID != null).WithMessage("Invalid reference");
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritoryByTerritoryID).When(x => x?.TerritoryID != null).WithMessage("Invalid reference");
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

		private async Task<bool> BeUniqueByAccountNumber(ApiCustomerRequestModel model,  CancellationToken cancellationToken)
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
	}
}

/*<Codenesium>
    <Hash>5df290afdcf5cc96e82cf735b6531ca8</Hash>
</Codenesium>*/