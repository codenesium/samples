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
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/