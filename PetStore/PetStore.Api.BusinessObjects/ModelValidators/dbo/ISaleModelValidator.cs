using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiSaleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6f05a65314590941c24e4e5b077fa678</Hash>
</Codenesium>*/