using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDepartmentServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDepartmentServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>2f688291765a03c4ca02ea93bb5bd78d</Hash>
</Codenesium>*/