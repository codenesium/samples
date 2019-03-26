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
	public abstract class AbstractApiStoreServerRequestModelValidator : AbstractValidator<ApiStoreServerRequestModel>
	{
		private int existingRecordId;

		protected IStoreRepository StoreRepository { get; private set; }

		public AbstractApiStoreServerRequestModelValidator(IStoreRepository storeRepository)
		{
			this.StoreRepository = storeRepository;
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
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiStoreServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).MustAsync(this.BeValidSalesPersonBySalesPersonID).When(x => !x?.SalesPersonID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidSalesPersonBySalesPersonID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.StoreRepository.SalesPersonBySalesPersonID(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeUniqueByRowguid(ApiStoreServerRequestModel model,  CancellationToken cancellationToken)
		{
			Store record = await this.StoreRepository.ByRowguid(model.Rowguid);

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
    <Hash>bfa4db0e76ccda46b5dff89fceac58fa</Hash>
</Codenesium>*/