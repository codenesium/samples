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
	public abstract class AbstractApiWorkOrderServerRequestModelValidator : AbstractValidator<ApiWorkOrderServerRequestModel>
	{
		private int existingRecordId;

		protected IWorkOrderRepository WorkOrderRepository { get; private set; }

		public AbstractApiWorkOrderServerRequestModelValidator(IWorkOrderRepository workOrderRepository)
		{
			this.WorkOrderRepository = workOrderRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiWorkOrderServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DueDateRules()
		{
		}

		public virtual void EndDateRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void OrderQtyRules()
		{
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).MustAsync(this.BeValidProductByProductID).When(x => !x?.ProductID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ScrappedQtyRules()
		{
		}

		public virtual void ScrapReasonIDRules()
		{
			this.RuleFor(x => x.ScrapReasonID).MustAsync(this.BeValidScrapReasonByScrapReasonID).When(x => !x?.ScrapReasonID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void StartDateRules()
		{
		}

		public virtual void StockedQtyRules()
		{
		}

		protected async Task<bool> BeValidProductByProductID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.WorkOrderRepository.ProductByProductID(id);

			return record != null;
		}

		protected async Task<bool> BeValidScrapReasonByScrapReasonID(short? id,  CancellationToken cancellationToken)
		{
			var record = await this.WorkOrderRepository.ScrapReasonByScrapReasonID(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>eb4e0f95cb1d8d7a3762f0e55c31b6a2</Hash>
</Codenesium>*/