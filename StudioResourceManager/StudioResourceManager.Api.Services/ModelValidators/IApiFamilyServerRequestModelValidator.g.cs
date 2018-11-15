using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiFamilyServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFamilyServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>557490fa455c885c1811d6460ea5ee3d</Hash>
</Codenesium>*/