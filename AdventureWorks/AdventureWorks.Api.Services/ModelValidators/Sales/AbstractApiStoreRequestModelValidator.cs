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
	public abstract class AbstractApiStoreRequestModelValidator : AbstractValidator<ApiStoreRequestModel>
	{
		private int existingRecordId;

		private IStoreRepository storeRepository;

		public AbstractApiStoreRequestModelValidator(IStoreRepository storeRepository)
		{
			this.storeRepository = storeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiStoreRequestModel model, int id)
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
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).MustAsync(this.BeValidSalesPerson).When(x => x?.SalesPersonID != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesPerson(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.storeRepository.GetSalesPerson(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a1894b0c610d944aa6df6bccc438b2ef</Hash>
</Codenesium>*/