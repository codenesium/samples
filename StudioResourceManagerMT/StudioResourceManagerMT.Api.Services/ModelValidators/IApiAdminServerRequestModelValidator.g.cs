using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiAdminServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bea3a48806f7e58bd7ed4ff896183636</Hash>
</Codenesium>*/