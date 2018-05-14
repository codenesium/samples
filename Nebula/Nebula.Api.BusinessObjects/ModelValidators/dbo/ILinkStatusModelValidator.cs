using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiLinkStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>39f4ef8fc11717c7e715d46a75dd0fce</Hash>
</Codenesium>*/