using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductSubcategoryService : AbstractService
	{
		protected IProductSubcategoryRepository ProductSubcategoryRepository { get; private set; }

		protected IApiProductSubcategoryServerRequestModelValidator ProductSubcategoryModelValidator { get; private set; }

		protected IBOLProductSubcategoryMapper BolProductSubcategoryMapper { get; private set; }

		protected IDALProductSubcategoryMapper DalProductSubcategoryMapper { get; private set; }

		protected IBOLProductMapper BolProductMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public AbstractProductSubcategoryService(
			ILogger logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryServerRequestModelValidator productSubcategoryModelValidator,
			IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base()
		{
			this.ProductSubcategoryRepository = productSubcategoryRepository;
			this.ProductSubcategoryModelValidator = productSubcategoryModelValidator;
			this.BolProductSubcategoryMapper = bolProductSubcategoryMapper;
			this.DalProductSubcategoryMapper = dalProductSubcategoryMapper;
			this.BolProductMapper = bolProductMapper;
			this.DalProductMapper = dalProductMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductSubcategoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductSubcategoryRepository.All(limit, offset);

			return this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductSubcategoryServerResponseModel> Get(int productSubcategoryID)
		{
			var record = await this.ProductSubcategoryRepository.Get(productSubcategoryID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductSubcategoryServerResponseModel>> Create(
			ApiProductSubcategoryServerRequestModel model)
		{
			CreateResponse<ApiProductSubcategoryServerResponseModel> response = ValidationResponseFactory<ApiProductSubcategoryServerResponseModel>.CreateResponse(await this.ProductSubcategoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolProductSubcategoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductSubcategoryRepository.Create(this.DalProductSubcategoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductSubcategoryServerResponseModel>> Update(
			int productSubcategoryID,
			ApiProductSubcategoryServerRequestModel model)
		{
			var validationResult = await this.ProductSubcategoryModelValidator.ValidateUpdateAsync(productSubcategoryID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductSubcategoryMapper.MapModelToBO(productSubcategoryID, model);
				await this.ProductSubcategoryRepository.Update(this.DalProductSubcategoryMapper.MapBOToEF(bo));

				var record = await this.ProductSubcategoryRepository.Get(productSubcategoryID);

				return ValidationResponseFactory<ApiProductSubcategoryServerResponseModel>.UpdateResponse(this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiProductSubcategoryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productSubcategoryID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));

			if (response.Success)
			{
				await this.ProductSubcategoryRepository.Delete(productSubcategoryID);
			}

			return response;
		}

		public async virtual Task<ApiProductSubcategoryServerResponseModel> ByName(string name)
		{
			ProductSubcategory record = await this.ProductSubcategoryRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<ApiProductSubcategoryServerResponseModel> ByRowguid(Guid rowguid)
		{
			ProductSubcategory record = await this.ProductSubcategoryRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiProductServerResponseModel>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.ProductSubcategoryRepository.ProductsByProductSubcategoryID(productSubcategoryID, limit, offset);

			return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ccfc4726c3aa47b5dc4d2c3bdcba3652</Hash>
</Codenesium>*/