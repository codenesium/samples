using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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

		public virtual void SalesReasonIDRules()
		{
			RuleFor(x => x.SalesReasonID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>7b2a70b1b86ef5a85c26f8ba8038d4cc</Hash>
</Codenesium>*/