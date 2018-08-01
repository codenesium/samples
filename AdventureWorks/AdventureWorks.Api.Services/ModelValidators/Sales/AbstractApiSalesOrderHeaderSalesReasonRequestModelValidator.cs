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
	public abstract class AbstractApiSalesOrderHeaderSalesReasonRequestModelValidator : AbstractValidator<ApiSalesOrderHeaderSalesReasonRequestModel>
	{
		private int existingRecordId;

		private ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;

		public AbstractApiSalesOrderHeaderSalesReasonRequestModelValidator(ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository)
		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderHeaderSalesReasonRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void SalesReasonIDRules()
		{
			this.RuleFor(x => x.SalesReasonID).MustAsync(this.BeValidSalesReason).When(x => x?.SalesReasonID != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesOrderHeader(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesOrderHeaderSalesReasonRepository.GetSalesOrderHeader(id);

			return record != null;
		}

		private async Task<bool> BeValidSalesReason(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesOrderHeaderSalesReasonRepository.GetSalesReason(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>5656953acc59fc5af649e14714201de9</Hash>
</Codenesium>*/