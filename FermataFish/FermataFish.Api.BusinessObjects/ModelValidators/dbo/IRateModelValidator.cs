using System;
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
    <Hash>2f9fa3153d08a3aac7186e00c916802c</Hash>
</Codenesium>*/