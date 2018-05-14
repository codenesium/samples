using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IApiPaymentTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>963b48e6870507f145b24f3781a58291</Hash>
</Codenesium>*/