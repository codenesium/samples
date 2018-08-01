using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiStateProvinceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6fbe75bd901fec0e68e0922e73d9765b</Hash>
</Codenesium>*/