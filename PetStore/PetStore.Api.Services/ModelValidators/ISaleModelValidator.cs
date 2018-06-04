using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.Services
{
	public interface IApiSaleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6e5a945a517f72f153476b7450b5085e</Hash>
</Codenesium>*/