using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiStateProvinceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>38dbc32e11e0f2bb91e0978f558d2810</Hash>
</Codenesium>*/