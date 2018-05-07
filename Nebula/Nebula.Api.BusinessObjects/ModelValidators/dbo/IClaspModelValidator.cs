using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IClaspModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ClaspModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ClaspModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bf29375ebafd9c784ba3a1299a58774d</Hash>
</Codenesium>*/