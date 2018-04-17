using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IStoreModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(StoreModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, StoreModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0b9df9bacaef3b7957bcaf7cb3ceb0ef</Hash>
</Codenesium>*/