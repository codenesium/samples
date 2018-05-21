using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOProductModel: AbstractBOManager
	{
		private IProductModelRepository productModelRepository;
		private IApiProductModelModelValidator productModelModelValidator;
		private ILogger logger;

		public AbstractBOProductModel(
			ILogger logger,
			IProductModelRepository productModelRepository,
			IApiProductModelModelValidator productModelModelValidator)
			: base()

		{
			this.productModelRepository = productModelRepository;
			this.productModelModelValidator = productModelModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductModel> Get(int productModelID)
		{
			return this.productModelRepository.Get(productModelID);
		}

		public virtual async Task<CreateResponse<POCOProductModel>> Create(
			ApiProductModelModel model)
		{
			CreateResponse<POCOProductModel> response = new CreateResponse<POCOProductModel>(await this.productModelModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductModel record = await this.productModelRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ApiProductModelModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				await this.productModelRepository.Update(productModelID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				await this.productModelRepository.Delete(productModelID);
			}
			return response;
		}

		public async Task<POCOProductModel> GetName(string name)
		{
			return await this.productModelRepository.GetName(name);
		}
		public async Task<List<POCOProductModel>> GetCatalogDescription(string catalogDescription)
		{
			return await this.productModelRepository.GetCatalogDescription(catalogDescription);
		}
		public async Task<List<POCOProductModel>> GetInstructions(string instructions)
		{
			return await this.productModelRepository.GetInstructions(instructions);
		}
	}
}

/*<Codenesium>
    <Hash>12bb48a4324c033e3f8498f379060e1e</Hash>
</Codenesium>*/