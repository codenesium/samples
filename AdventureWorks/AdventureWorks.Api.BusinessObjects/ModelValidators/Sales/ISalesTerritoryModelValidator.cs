using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesTerritoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>db6a82be43942b4a90ee421ee35cb9b0</Hash>
</Codenesium>*/