using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPersonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PersonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PersonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1d8e58df3334380e65b185b122c69c15</Hash>
</Codenesium>*/