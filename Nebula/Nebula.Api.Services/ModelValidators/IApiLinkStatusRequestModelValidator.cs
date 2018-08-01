using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiLinkStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>22f290a16a91f641cc2120894f587340</Hash>
</Codenesium>*/