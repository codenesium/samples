using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiLinkLogModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkLogModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>da403178969f22054eade0d7183dff02</Hash>
</Codenesium>*/