using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiFileTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e6eff9420b4e55a23f682ab9f1072d47</Hash>
</Codenesium>*/