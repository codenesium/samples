using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISpecialOfferModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SpecialOfferModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SpecialOfferModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cc564bf332f6b3f3d04ce24b9cd40d60</Hash>
</Codenesium>*/