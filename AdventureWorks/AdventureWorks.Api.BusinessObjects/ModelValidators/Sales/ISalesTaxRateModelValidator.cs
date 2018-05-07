using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesTaxRateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesTaxRateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesTaxRateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0bf5d124faa0402d31c085e284ef1fb5</Hash>
</Codenesium>*/