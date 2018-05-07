using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IStoreModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(StoreModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, StoreModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c0cf67f98e8ee672b45114e580a1d260</Hash>
</Codenesium>*/