using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiFamilyServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFamilyServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e2fe01e3753540807648c79a242c8cdb</Hash>
</Codenesium>*/