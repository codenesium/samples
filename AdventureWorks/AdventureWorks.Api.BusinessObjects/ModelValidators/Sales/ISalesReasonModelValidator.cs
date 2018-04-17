using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesReasonModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesReasonModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesReasonModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d7840bb60d4b0c8381f05b3225ccbc82</Hash>
</Codenesium>*/