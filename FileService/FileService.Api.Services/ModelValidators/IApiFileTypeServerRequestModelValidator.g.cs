using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial interface IApiFileTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>76e13a62d6d1c317a3565325e46670e2</Hash>
</Codenesium>*/