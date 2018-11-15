using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiStateProvinceServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>52896f41eb9de0ee13eacab5d583b06d</Hash>
</Codenesium>*/