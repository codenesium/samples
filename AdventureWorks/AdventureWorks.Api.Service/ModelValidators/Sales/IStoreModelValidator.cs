using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IStoreModelValidator
	{
		ValidationResult Validate(StoreModel entity);

		Task<ValidationResult> ValidateAsync(StoreModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>0539c3a5a383cf6051372e5d4476f32b</Hash>
</Codenesium>*/