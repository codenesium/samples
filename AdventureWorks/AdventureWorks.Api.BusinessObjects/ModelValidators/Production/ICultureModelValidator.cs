using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICultureModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CultureModel model);
		Task<ValidationResult>  ValidateUpdateAsync(string id, CultureModel model);
		Task<ValidationResult>  ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>7a722218f47ea0a0ebd051ff9bd4fdc4</Hash>
</Codenesium>*/