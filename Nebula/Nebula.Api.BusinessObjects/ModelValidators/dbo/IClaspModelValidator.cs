using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IClaspModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ClaspModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ClaspModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a348cd944f45a787adf4ad9398d4366f</Hash>
</Codenesium>*/