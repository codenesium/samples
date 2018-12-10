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
		}

		public virtual void ScrappedQtyRules()
		{
		}

		public virtual void ScrapReasonIDRules()
		{
		}

		public virtual void StartDateRules()
		{
		}

		public virtual void StockedQtyRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e13492fde7c2a41b66c6e25a76374dd4</Hash>
</Codenesium>*/