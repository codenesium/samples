using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IContactTypeModelValidator
	{
		ValidationResult Validate(ContactTypeModel entity);

		Task<ValidationResult> ValidateAsync(ContactTypeModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>cbdcfdf30459118c0f14246701f1a45b</Hash>
</Codenesium>*/