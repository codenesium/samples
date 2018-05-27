using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductVendorRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductVendorRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductVendorRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c43d7537c27c2787316d68db6f042c5f</Hash>
</Codenesium>*/