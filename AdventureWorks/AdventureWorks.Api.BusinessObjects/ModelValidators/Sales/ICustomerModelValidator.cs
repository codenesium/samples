using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCustomerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>524ac7fdf825c181cd7f98afa97e1372</Hash>
</Codenesium>*/