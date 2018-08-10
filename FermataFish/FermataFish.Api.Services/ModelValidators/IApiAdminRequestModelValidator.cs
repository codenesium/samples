using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiAdminRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9690bcf9865f741df6c7cb27a11dbcf5</Hash>
</Codenesium>*/