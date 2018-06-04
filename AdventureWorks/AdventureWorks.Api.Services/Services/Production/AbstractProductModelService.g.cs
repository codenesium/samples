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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductModelService: AbstractService
	{
		private IProductModelRepository productModelRepository;
		private IApiProductModelRequestModelValidator productModelModelValidator;
		private IBOLProductModelMapper BOLProductModelMapper;
		private IDALProductModelMapper DALProductModelMapper;
		private ILogger logger;

		public AbstractProductModelService(
			ILogger logger,
			IProductModelRepository productModelRepository,
			IApiProductModelRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper bolproductModelMapper,
			IDALProductModelMapper dalproductModelMapper)
			: base()

		{
			this.productModelRepository = productModelRepository;
			this.productModelModelValidator = productModelModelValidator;
			this.BOLProductModelMapper = bolproductModelMapper;
			this.DALProductModelMapper = dalproductModelMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productModelRepository.All(skip, take, orderClause);

			return this.BOLProductModelMapper.MapBOToModel(this.DALProductModelMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductModelResponseModel> Get(int productModelID)
		{
			var record = await productModelRepository.Get(productModelID);

			return this.BOLProductModelMapper.MapBOToModel(this.DALProductModelMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductModelResponseModel>> Create(
			ApiProductModelRequestModel model)
		{
			CreateResponse<ApiProductModelResponseModel> response = new CreateResponse<ApiProductModelResponseModel>(await this.productModelModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductModelMapper.MapModelToBO(default (int), model);
				var record = await this.productModelRepository.Create(this.DALProductModelMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductModelMapper.MapBOToModel(this.DALProductModelMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ApiProductModelRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				var bo = this.BOLProductModelMapper.MapModelToBO(productModelID, model);
				await this.productModelRepository.Update(this.DALProductModelMapper.MapBOToEF(bo));
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

		public async Task<ApiProductModelResponseModel> GetName(string name)
		{
			ProductModel record = await this.productModelRepository.GetName(name);

			return this.BOLProductModelMapper.MapBOToModel(this.DALProductModelMapper.MapEFToBO(record));
		}
		public async Task<List<ApiProductModelResponseModel>> GetCatalogDescription(string catalogDescription)
		{
			List<ProductModel> records = await this.productModelRepository.GetCatalogDescription(catalogDescription);

			return this.BOLProductModelMapper.MapBOToModel(this.DALProductModelMapper.MapEFToBO(records));
		}
		public async Task<List<ApiProductModelResponseModel>> GetInstructions(string instructions)
		{
			List<ProductModel> records = await this.productModelRepository.GetInstructions(instructions);

			return this.BOLProductModelMapper.MapBOToModel(this.DALProductModelMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>198b6652d55fc9020fac157d042ec90d</Hash>
</Codenesium>*/