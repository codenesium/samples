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
	public abstract class AbstractProductService : AbstractService
	{
		protected IProductRepository ProductRepository { get; private set; }

		protected IApiProductRequestModelValidator ProductModelValidator { get; private set; }

		protected IBOLProductMapper BolProductMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		protected IBOLBillOfMaterialMapper BolBillOfMaterialMapper { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		protected IBOLProductCostHistoryMapper BolProductCostHistoryMapper { get; private set; }

		protected IDALProductCostHistoryMapper DalProductCostHistoryMapper { get; private set; }

		protected IBOLProductInventoryMapper BolProductInventoryMapper { get; private set; }

		protected IDALProductInventoryMapper DalProductInventoryMapper { get; private set; }

		protected IBOLProductListPriceHistoryMapper BolProductListPriceHistoryMapper { get; private set; }

		protected IDALProductListPriceHistoryMapper DalProductListPriceHistoryMapper { get; private set; }

		protected IBOLProductProductPhotoMapper BolProductProductPhotoMapper { get; private set; }

		protected IDALProductProductPhotoMapper DalProductProductPhotoMapper { get; private set; }

		protected IBOLProductReviewMapper BolProductReviewMapper { get; private set; }

		protected IDALProductReviewMapper DalProductReviewMapper { get; private set; }

		protected IBOLTransactionHistoryMapper BolTransactionHistoryMapper { get; private set; }

		protected IDALTransactionHistoryMapper DalTransactionHistoryMapper { get; private set; }

		protected IBOLWorkOrderMapper BolWorkOrderMapper { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractProductService(
			ILogger logger,
			IProductRepository productRepository,
			IApiProductRequestModelValidator productModelValidator,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IBOLProductCostHistoryMapper bolProductCostHistoryMapper,
			IDALProductCostHistoryMapper dalProductCostHistoryMapper,
			IBOLProductInventoryMapper bolProductInventoryMapper,
			IDALProductInventoryMapper dalProductInventoryMapper,
			IBOLProductListPriceHistoryMapper bolProductListPriceHistoryMapper,
			IDALProductListPriceHistoryMapper dalProductListPriceHistoryMapper,
			IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper,
			IBOLProductReviewMapper bolProductReviewMapper,
			IDALProductReviewMapper dalProductReviewMapper,
			IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base()
		{
			this.ProductRepository = productRepository;
			this.ProductModelValidator = productModelValidator;
			this.BolProductMapper = bolProductMapper;
			this.DalProductMapper = dalProductMapper;
			this.BolBillOfMaterialMapper = bolBillOfMaterialMapper;
			this.DalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.BolProductCostHistoryMapper = bolProductCostHistoryMapper;
			this.DalProductCostHistoryMapper = dalProductCostHistoryMapper;
			this.BolProductInventoryMapper = bolProductInventoryMapper;
			this.DalProductInventoryMapper = dalProductInventoryMapper;
			this.BolProductListPriceHistoryMapper = bolProductListPriceHistoryMapper;
			this.DalProductListPriceHistoryMapper = dalProductListPriceHistoryMapper;
			this.BolProductProductPhotoMapper = bolProductProductPhotoMapper;
			this.DalProductProductPhotoMapper = dalProductProductPhotoMapper;
			this.BolProductReviewMapper = bolProductReviewMapper;
			this.DalProductReviewMapper = dalProductReviewMapper;
			this.BolTransactionHistoryMapper = bolTransactionHistoryMapper;
			this.DalTransactionHistoryMapper = dalTransactionHistoryMapper;
			this.BolWorkOrderMapper = bolWorkOrderMapper;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductRepository.All(limit, offset);

			return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductResponseModel> Get(int productID)
		{
			var record = await this.ProductRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductResponseModel>> Create(
			ApiProductRequestModel model)
		{
			CreateResponse<ApiProductResponseModel> response = new CreateResponse<ApiProductResponseModel>(await this.ProductModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductMapper.MapModelToBO(default(int), model);
				var record = await this.ProductRepository.Create(this.DalProductMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductResponseModel>> Update(
			int productID,
			ApiProductRequestModel model)
		{
			var validationResult = await this.ProductModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductMapper.MapModelToBO(productID, model);
				await this.ProductRepository.Update(this.DalProductMapper.MapBOToEF(bo));

				var record = await this.ProductRepository.Get(productID);

				return new UpdateResponse<ApiProductResponseModel>(this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.ProductModelValidator.ValidateDeleteAsync(productID));
			if (response.Success)
			{
				await this.ProductRepository.Delete(productID);
			}

			return response;
		}

		public async Task<ApiProductResponseModel> ByName(string name)
		{
			Product record = await this.ProductRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiProductResponseModel> ByProductNumber(string productNumber)
		{
			Product record = await this.ProductRepository.ByProductNumber(productNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterials(int productAssemblyID, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.ProductRepository.BillOfMaterials(productAssemblyID, limit, offset);

			return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductCostHistory> records = await this.ProductRepository.ProductCostHistories(productID, limit, offset);

			return this.BolProductCostHistoryMapper.MapBOToModel(this.DalProductCostHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductInventoryResponseModel>> ProductInventories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductInventory> records = await this.ProductRepository.ProductInventories(productID, limit, offset);

			return this.BolProductInventoryMapper.MapBOToModel(this.DalProductInventoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductListPriceHistory> records = await this.ProductRepository.ProductListPriceHistories(productID, limit, offset);

			return this.BolProductListPriceHistoryMapper.MapBOToModel(this.DalProductListPriceHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoes(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductProductPhoto> records = await this.ProductRepository.ProductProductPhotoes(productID, limit, offset);

			return this.BolProductProductPhotoMapper.MapBOToModel(this.DalProductProductPhotoMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductReviewResponseModel>> ProductReviews(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductReview> records = await this.ProductRepository.ProductReviews(productID, limit, offset);

			return this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTransactionHistoryResponseModel>> TransactionHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<TransactionHistory> records = await this.ProductRepository.TransactionHistories(productID, limit, offset);

			return this.BolTransactionHistoryMapper.MapBOToModel(this.DalTransactionHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiWorkOrderResponseModel>> WorkOrders(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrder> records = await this.ProductRepository.WorkOrders(productID, limit, offset);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>57897916234b6b459c70574363d5f323</Hash>
</Codenesium>*/