using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IPenModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PenModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PenModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cfdb4febbb47a5f03c5953cf40c0220f</Hash>
</Codenesium>*/