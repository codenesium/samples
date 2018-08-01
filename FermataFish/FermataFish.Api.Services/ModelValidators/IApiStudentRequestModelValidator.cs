using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>5ef03f54bb08243e1d2c9016b50ecd1b</Hash>
</Codenesium>*/