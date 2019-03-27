using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiUnitOfficerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitOfficerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUnitOfficerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f822473465963fc7ebe5663ae4288ad2</Hash>
</Codenesium>*/