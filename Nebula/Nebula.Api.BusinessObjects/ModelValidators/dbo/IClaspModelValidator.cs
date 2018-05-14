using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiClaspModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClaspModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4b44d37719823d8777be97cfd38c0612</Hash>
</Codenesium>*/