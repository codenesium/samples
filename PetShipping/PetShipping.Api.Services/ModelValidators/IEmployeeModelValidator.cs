using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiEmployeeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d396f425dc33f43abda491d6d848d5c3</Hash>
</Codenesium>*/