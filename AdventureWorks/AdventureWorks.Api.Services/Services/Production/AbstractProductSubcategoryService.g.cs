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
	public abstract class AbstractProductSubcategoryService : AbstractService
	{
		protected IProductSubcategoryRepository ProductSubcategoryRepository { get; private set; }

		protected IApiProductSubcategoryRequestModelValidator ProductSubcategoryModelValidator { get; private set; }

		protected IBOLProductSubcategoryMapper BolProductSubcategoryMapper { get; private set; }

		protected IDALProductSubcategoryMapper DalProductSubcategoryMapper { get; private set; }

		protected IBOLProductMapper BolProductMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public AbstractProductSubcategoryService(
			ILogger logger,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
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

		public virtual async Task<List<ApiProductSubcategoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductSubcategoryRepository.All(limit, offset);

			return this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductSubcategoryResponseModel> Get(int productSubcategoryID)
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

		public virtual async Task<CreateResponse<ApiProductSubcategoryResponseModel>> Create(
			ApiProductSubcategoryRequestModel model)
		{
			CreateResponse<ApiProductSubcategoryResponseModel> response = new CreateResponse<ApiProductSubcategoryResponseModel>(await this.ProductSubcategoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductSubcategoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductSubcategoryRepository.Create(this.DalProductSubcategoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductSubcategoryResponseModel>> Update(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel model)
		{
			var validationResult = await this.ProductSubcategoryModelValidator.ValidateUpdateAsync(productSubcategoryID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductSubcategoryMapper.MapModelToBO(productSubcategoryID, model);
				await this.ProductSubcategoryRepository.Update(this.DalProductSubcategoryMapper.MapBOToEF(bo));

				var record = await this.ProductSubcategoryRepository.Get(productSubcategoryID);

				return new UpdateResponse<ApiProductSubcategoryResponseModel>(this.BolProductSubcategoryMapper.MapBOToModel(this.DalProductSubcategoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductSubcategoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productSubcategoryID)
		{
			ActionResponse response = new ActionResponse(await this.ProductSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));
			if (response.Success)
			{
				await this.ProductSubcategoryRepository.Delete(productSubcategoryID);
			}

			return response;
		}

		public async Task<ApiProductSubcategoryResponseModel> ByName(string name)
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

		public async virtual Task<List<ApiProductResponseModel>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.ProductSubcategoryRepository.ProductsByProductSubcategoryID(productSubcategoryID, limit, offset);

			return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4dacea871e89e7ecfdd136ba98a38c69</Hash>
</Codenesium>*/