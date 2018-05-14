using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiSaleModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>86fd266e88833403843e3a7da93c238a</Hash>
</Codenesium>*/