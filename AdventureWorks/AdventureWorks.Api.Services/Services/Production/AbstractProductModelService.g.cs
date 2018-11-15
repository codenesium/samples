using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductModelService : AbstractService
	{
		protected IProductModelRepository ProductModelRepository { get; private set; }

		protected IApiProductModelServerRequestModelValidator ProductModelModelValidator { get; private set; }

		protected IBOLProductModelMapper BolProductModelMapper { get; private set; }

		protected IDALProductModelMapper DalProductModelMapper { get; private set; }

		protected IBOLProductMapper BolProductMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public AbstractProductModelService(
			ILogger logger,
			IProductModelRepository productModelRepository,
			IApiProductModelServerRequestModelValidator productModelModelValidator,
			IBOLProductModelMapper bolProductModelMapper,
			IDALProductModelMapper dalProductModelMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base()
		{
			this.ProductModelRepository = productModelRepository;
			this.ProductModelModelValidator = productModelModelValidator;
			this.BolProductModelMapper = bolProductModelMapper;
			this.DalProductModelMapper = dalProductModelMapper;
			this.BolProductMapper = bolProductMapper;
			this.DalProductMapper = dalProductMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductModelServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductModelRepository.All(limit, offset);

			return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductModelServerResponseModel> Get(int productModelID)
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

		public virtual async Task<CreateResponse<ApiProductModelServerResponseModel>> Create(
			ApiProductModelServerRequestModel model)
		{
			CreateResponse<ApiProductModelServerResponseModel> response = ValidationResponseFactory<ApiProductModelServerResponseModel>.CreateResponse(await this.ProductModelModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolProductModelMapper.MapModelToBO(default(int), model);
				var record = await this.ProductModelRepository.Create(this.DalProductModelMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductModelServerResponseModel>> Update(
			int productModelID,
			ApiProductModelServerRequestModel model)
		{
			var validationResult = await this.ProductModelModelValidator.ValidateUpdateAsync(productModelID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductModelMapper.MapModelToBO(productModelID, model);
				await this.ProductModelRepository.Update(this.DalProductModelMapper.MapBOToEF(bo));

				var record = await this.ProductModelRepository.Get(productModelID);

				return ValidationResponseFactory<ApiProductModelServerResponseModel>.UpdateResponse(this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiProductModelServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductModelModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				await this.ProductModelRepository.Delete(productModelID);
			}

			return response;
		}

		public async virtual Task<ApiProductModelServerResponseModel> ByName(string name)
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

		public async virtual Task<ApiProductModelServerResponseModel> ByRowguid(Guid rowguid)
		{
			ProductModel record = await this.ProductModelRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiProductModelServerResponseModel>> ByCatalogDescription(string catalogDescription, int limit = 0, int offset = int.MaxValue)
		{
			List<ProductModel> records = await this.ProductModelRepository.ByCatalogDescription(catalogDescription, limit, offset);

			return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductModelServerResponseModel>> ByInstruction(string instruction, int limit = 0, int offset = int.MaxValue)
		{
			List<ProductModel> records = await this.ProductModelRepository.ByInstruction(instruction, limit, offset);

			return this.BolProductModelMapper.MapBOToModel(this.DalProductModelMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductServerResponseModel>> ProductsByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.ProductModelRepository.ProductsByProductModelID(productModelID, limit, offset);

			return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>46e030e06ede95d58edd24b89367c815</Hash>
</Codenesium>*/