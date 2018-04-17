using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IStudioModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StudioModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StudioModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>02b94f74ccee9ef261c136eae256e71a</Hash>
</Codenesium>*/