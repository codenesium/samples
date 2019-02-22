using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiPersonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>48582cc0e5b86b8df26bd6d890f916e2</Hash>
</Codenesium>*/