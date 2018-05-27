using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesOrderHeaderSalesReasonRequestModelValidator: AbstractValidator<ApiSalesOrderHeaderSalesReasonRequestModel>
	{
		public new ValidationResult Validate(ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; set; }
		public ISalesReasonRepository SalesReasonRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void SalesReasonIDRules()
		{
			this.RuleFor(x => x.SalesReasonID).NotNull();
			this.RuleFor(x => x.SalesReasonID).MustAsync(this.BeValidSalesReason).When(x => x ?.SalesReasonID != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesOrderHeader(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesOrderHeaderRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidSalesReason(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesReasonRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>e21bb7300e1393a43b053dd7ea793687</Hash>
</Codenesium>*/