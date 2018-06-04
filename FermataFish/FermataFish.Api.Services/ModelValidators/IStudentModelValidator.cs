using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiStudentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ccebfd3ce8b8508d35a9756a57cc13bd</Hash>
</Codenesium>*/