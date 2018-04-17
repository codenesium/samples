using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractSalesOrderHeaderSalesReasonModelValidator: AbstractValidator<SalesOrderHeaderSalesReasonModel>
	{
		public new ValidationResult Validate(SalesOrderHeaderSalesReasonModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesOrderHeaderSalesReasonModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; set; }
		public ISalesReasonRepository SalesReasonRepository { get; set; }
		public virtual void SalesReasonIDRules()
		{
			this.RuleFor(x => x.SalesReasonID).NotNull();
			this.RuleFor(x => x.SalesReasonID).Must(this.BeValidSalesReason).When(x => x ?.SalesReasonID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidSalesOrderHeader(int id)
		{
			return this.SalesOrderHeaderRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidSalesReason(int id)
		{
			return this.SalesReasonRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>bf2854b8b5282eeb0fc45ba9645710ef</Hash>
</Codenesium>*/