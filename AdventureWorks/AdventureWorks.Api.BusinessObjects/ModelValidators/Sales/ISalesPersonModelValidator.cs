using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesPersonModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SalesPersonModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SalesPersonModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>82b46f9b9d8a15229a6705250d528ff7</Hash>
</Codenesium>*/