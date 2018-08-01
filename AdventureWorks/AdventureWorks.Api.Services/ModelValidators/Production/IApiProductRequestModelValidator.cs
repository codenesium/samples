using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e63fadfcaa98cba55997305cf3267630</Hash>
</Codenesium>*/