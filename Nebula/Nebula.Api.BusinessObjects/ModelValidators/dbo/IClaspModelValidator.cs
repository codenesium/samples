using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiClaspRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClaspRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6b48d8e758a9e62e01b8cfdff326d878</Hash>
</Codenesium>*/