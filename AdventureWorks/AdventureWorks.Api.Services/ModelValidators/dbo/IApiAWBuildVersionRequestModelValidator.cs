using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiAWBuildVersionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9c114ce26cadf9ef1445ea8e32a49a03</Hash>
</Codenesium>*/