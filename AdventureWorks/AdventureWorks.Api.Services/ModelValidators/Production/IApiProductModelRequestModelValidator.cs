using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductModelRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8a59b6c70da454d400e9a058afd09808</Hash>
</Codenesium>*/