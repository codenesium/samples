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
    <Hash>164593c271b12a0d14c1e3b89bb7c082</Hash>
</Codenesium>*/