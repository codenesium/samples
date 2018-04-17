using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IRateModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(RateModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, RateModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7951707098e62d259af61c351f6b642a</Hash>
</Codenesium>*/