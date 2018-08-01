using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiAdminRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e103209246582af31ea221764a0512fe</Hash>
</Codenesium>*/