using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPersonModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PersonModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PersonModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f5f75f8444762e7ade8432211ad00d5f</Hash>
</Codenesium>*/