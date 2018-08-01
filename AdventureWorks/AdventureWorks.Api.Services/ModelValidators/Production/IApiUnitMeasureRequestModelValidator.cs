using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiUnitMeasureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>d881e5e4f1f10ac02ab6a23e84e0685c</Hash>
</Codenesium>*/