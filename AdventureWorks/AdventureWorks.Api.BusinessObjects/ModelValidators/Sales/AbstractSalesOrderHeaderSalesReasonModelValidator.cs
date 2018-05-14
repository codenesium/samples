using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesOrderHeaderSalesReasonModelValidator: AbstractValidator<ApiSalesOrderHeaderSalesReasonModel>
	{
		public new ValidationResult Validate(ApiSalesOrderHeaderSalesReasonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderHeaderSalesReasonModel model)
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
			this.RuleFor(x => x.SalesReasonID).Must(this.BeValidSalesReason).When(x => x ?.SalesReasonID != null).WithMessage("Invalid reference");
		}

		private bool BeValidSalesOrderHeader(int id)
		{
			return this.SalesOrderHeaderRepository.Get(id) != null;
		}

		private bool BeValidSalesReason(int id)
		{
			return this.SalesReasonRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>cf2a23806d7fd3221e6956c2af6242dd</Hash>
</Codenesium>*/