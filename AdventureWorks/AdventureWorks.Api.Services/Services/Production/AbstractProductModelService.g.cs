using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductModelService : AbstractService
	{
		protected IProductModelRepository ProductModelRepository { get; private set; }

		protected IApiProductModelRequestModelValidator ProductModelModelValidator { get; private set; }

		protected IBOLProductModelMapper BolProductModelMapper { get; private set; }

		protected IDALProductModelMapper DalProductModelMapper { get; private set; }

		protected IBOLProductMapper BolProductMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		protected IBOLProductModelProductDescriptionCultureMapper BolProductModelProductDescriptionCultureMapper { get; private set; }

		protected IDALProductModelProductDescriptionCultureMapper DalProductModelProductDescriptionCultureMapper { get; private set; }

		private ILogger logger;

		public AbstractProductModelService(
			ILogger logger,
			IProductModelRepository productModelRepository,
			IApiProductModelRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper bolProductModelMapper,
			IDALProductModelMapper dalProductModelMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
			: base()
		{
			this.ProductModelRepository = productModelRepository;
			this.ProductModelModelValidator = productModelModelValidator;
			this.BolProductModelMapper = bolProductModelMapper;
			this.DalProductModelMapper = dalProductModelMapper;
			this.BolProductMapper = bolProductMapper;
			this.DalProductMapper = dalProductMapper;
			this.BolProductModelProductDescriptionCultureMapper = bolProductModelProductDescriptionCultureMapper;
			this.DalProductModelProductDescriptionCultureMapper = dalProductModelProductDescriptionCultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductModelRepository.All(limit, offset);

			return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductModelResponseModel> Get(int productModelID)
		{
			var record = await this.ProductModelRepository.Get(productModelID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductModelResponseModel>> Create(
			ApiProductModelRequestModel model)
		{
			CreateResponse<ApiProductModelResponseModel> response = new CreateResponse<ApiProductModelResponseModel>(await this.ProductModelModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductModelMapper.MapModelToBO(default(int), model);
				var record = await this.ProductModelRepository.Create(this.DalProductModelMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductModelResponseModel>> Update(
			int productModelID,
			ApiProductModelRequestModel model)
		{
			var validationResult = await this.ProductModelModelValidator.ValidateUpdateAsync(productModelID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductModelMapper.MapModelToBO(productModelID, model);
				await this.ProductModelRepository.Update(this.DalProductModelMapper.MapBOToEF(bo));

				var record = await this.ProductModelRepository.Get(productModelID);

				return new UpdateResponse<ApiProductModelResponseModel>(this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductModelResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.ProductModelModelValidator.ValidateDeleteAsync(productModelID));
			if (response.Success)
			{
				await this.ProductModelRepository.Delete(productModelID);
			}

			return response;
		}

		public async Task<ApiProductModelResponseModel> ByName(string name)
		{
			ProductModel record = await this.ProductModelRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiProductModelResponseModel>> ByCatalogDescription(string catalogDescription, int limit = 0, int offset = int.MaxValue)
		{
			List<ProductModel> records = await this.ProductModelRepository.ByCatalogDescription(catalogDescription, limit, offset);

			return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(records));
		}

		public async Task<List<ApiProductModelResponseModel>> ByInstruction(string instruction, int limit = 0, int offset = int.MaxValue)
		{
			List<ProductModel> records = await this.ProductModelRepository.ByInstruction(instruction, limit, offset);

			return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductResponseModel>> Products(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.ProductModelRepository.Products(productModelID, limit, offset);

			return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductModelProductDescriptionCulture> records = await this.ProductModelRepository.ProductModelProductDescriptionCultures(productModelID, limit, offset);

			return this.BolProductModelProductDescriptionCultureMapper.MapBOToModel(this.DalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductModelResponseModel>> ByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductModel> records = await this.ProductModelRepository.ByProductModelID(productModelID, limit, offset);

			return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d94926df35d68dbcccd65001959a1f18</Hash>
</Codenesium>*/