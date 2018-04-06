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

		public ISalesOrderHeaderRepository SalesOrderHeaderRepository {get; set;}
		public ISalesReasonRepository SalesReasonRepository {get; set;}
		public virtual void SalesReasonIDRules()
		{
			RuleFor(x => x.SalesReasonID).NotNull();
			RuleFor(x => x.SalesReasonID).Must(BeValidSalesReason).When(x => x ?.SalesReasonID != null).WithMessage("Invalid reference");
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidSalesOrderHeader(int id)
		{
			Response response = new Response();

			this.SalesOrderHeaderRepository.GetById(id,response);
			return response.SalesOrderHeaders.Count > 0;
		}

		public bool BeValidSalesReason(int id)
		{
			Response response = new Response();

			this.SalesReasonRepository.GetById(id,response);
			return response.SalesReasons.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>e56a2495825930270ed7fd3ceb840404</Hash>
</Codenesium>*/