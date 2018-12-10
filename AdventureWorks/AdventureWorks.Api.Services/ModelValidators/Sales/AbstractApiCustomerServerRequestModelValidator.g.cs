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
	public abstract class AbstractApiCustomerServerRequestModelValidator : AbstractValidator<ApiCustomerServerRequestModel>
	{
		private int existingRecordId;

		protected ICustomerRepository CustomerRepository { get; private set; }

		public AbstractApiCustomerServerRequestModelValidator(ICustomerRepository customerRepository)
		{
			this.CustomerRepository = customerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCustomerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByAccountNumber).When(x => (!x?.AccountNumber.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiCustomerServerRequestModel.AccountNumber)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.AccountNumber).Length(0, 10).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void PersonIDRules()
		{
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiCustomerServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void StoreIDRules()
		{
			this.RuleFor(x => x.StoreID).MustAsync(this.BeValidStoreByStoreID).When(x => !x?.StoreID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TerritoryIDRules()
		{
			this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritoryByTerritoryID).When(x => !x?.TerritoryID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidStoreByStoreID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.CustomerRepository.StoreByStoreID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidSalesTerritoryByTerritoryID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.CustomerRepository.SalesTerritoryByTerritoryID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeUniqueByAccountNumber(ApiCustomerServerRequestModel model,  CancellationToken cancellationToken)
		{
			Customer record = await this.CustomerRepository.ByAccountNumber(model.AccountNumber);

			if (record == null || (this.existingRecordId != default(int) && record.CustomerID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiCustomerServerRequestModel model,  CancellationToken cancellationToken)
		{
			Customer record = await this.CustomerRepository.ByRowguid(model.Rowguid);

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
    <Hash>c4bf6c61186f13832ae6f74788fd22ff</Hash>
</Codenesium>*/