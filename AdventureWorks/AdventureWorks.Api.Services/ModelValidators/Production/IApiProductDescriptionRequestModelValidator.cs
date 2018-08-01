using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductDescriptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7f054688befd49ee2b92a9080c2a77fc</Hash>
</Codenesium>*/