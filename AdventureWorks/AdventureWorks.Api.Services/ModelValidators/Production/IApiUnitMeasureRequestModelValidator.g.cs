using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiUnitMeasureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>7d8c40d988af14592208d28fca0c8c47</Hash>
</Codenesium>*/