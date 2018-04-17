using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ILocationModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LocationModel model);
		Task<ValidationResult>  ValidateUpdateAsync(short id, LocationModel model);
		Task<ValidationResult>  ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>9327ec29e7c505a6995c614eb8285b69</Hash>
</Codenesium>*/