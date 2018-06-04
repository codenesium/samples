using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.Services
{
	public interface IApiDeviceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3b0b2232e305a53f459e36b23cdef718</Hash>
</Codenesium>*/