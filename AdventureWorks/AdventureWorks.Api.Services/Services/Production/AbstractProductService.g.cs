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
		private IProductRepository productRepository;

		private IApiProductRequestModelValidator productModelValidator;

		private IBOLProductMapper bolProductMapper;

		private IDALProductMapper dalProductMapper;

		private IBOLBillOfMaterialMapper bolBillOfMaterialMapper;

		private IDALBillOfMaterialMapper dalBillOfMaterialMapper;
		private IBOLProductCostHistoryMapper bolProductCostHistoryMapper;

		private IDALProductCostHistoryMapper dalProductCostHistoryMapper;
		private IBOLProductInventoryMapper bolProductInventoryMapper;

		private IDALProductInventoryMapper dalProductInventoryMapper;
		private IBOLProductListPriceHistoryMapper bolProductListPriceHistoryMapper;

		private IDALProductListPriceHistoryMapper dalProductListPriceHistoryMapper;
		private IBOLProductProductPhotoMapper bolProductProductPhotoMapper;

		private IDALProductProductPhotoMapper dalProductProductPhotoMapper;
		private IBOLProductReviewMapper bolProductReviewMapper;

		private IDALProductReviewMapper dalProductReviewMapper;
		private IBOLTransactionHistoryMapper bolTransactionHistoryMapper;

		private IDALTransactionHistoryMapper dalTransactionHistoryMapper;
		private IBOLWorkOrderMapper bolWorkOrderMapper;

		private IDALWorkOrderMapper dalWorkOrderMapper;

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
			this.productRepository = productRepository;
			this.productModelValidator = productModelValidator;
			this.bolProductMapper = bolProductMapper;
			this.dalProductMapper = dalProductMapper;
			this.bolBillOfMaterialMapper = bolBillOfMaterialMapper;
			this.dalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.bolProductCostHistoryMapper = bolProductCostHistoryMapper;
			this.dalProductCostHistoryMapper = dalProductCostHistoryMapper;
			this.bolProductInventoryMapper = bolProductInventoryMapper;
			this.dalProductInventoryMapper = dalProductInventoryMapper;
			this.bolProductListPriceHistoryMapper = bolProductListPriceHistoryMapper;
			this.dalProductListPriceHistoryMapper = dalProductListPriceHistoryMapper;
			this.bolProductProductPhotoMapper = bolProductProductPhotoMapper;
			this.dalProductProductPhotoMapper = dalProductProductPhotoMapper;
			this.bolProductReviewMapper = bolProductReviewMapper;
			this.dalProductReviewMapper = dalProductReviewMapper;
			this.bolTransactionHistoryMapper = bolTransactionHistoryMapper;
			this.dalTransactionHistoryMapper = dalTransactionHistoryMapper;
			this.bolWorkOrderMapper = bolWorkOrderMapper;
			this.dalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.productRepository.All(limit, offset);

			return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductResponseModel> Get(int productID)
		{
			var record = await this.productRepository.Get(productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductResponseModel>> Create(
			ApiProductRequestModel model)
		{
			CreateResponse<ApiProductResponseModel> response = new CreateResponse<ApiProductResponseModel>(await this.productModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolProductMapper.MapModelToBO(default(int), model);
				var record = await this.productRepository.Create(this.dalProductMapper.MapBOToEF(bo));

				response.SetRecord(this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductResponseModel>> Update(
			int productID,
			ApiProductRequestModel model)
		{
			var validationResult = await this.productModelValidator.ValidateUpdateAsync(productID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolProductMapper.MapModelToBO(productID, model);
				await this.productRepository.Update(this.dalProductMapper.MapBOToEF(bo));

				var record = await this.productRepository.Get(productID);

				return new UpdateResponse<ApiProductResponseModel>(this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productModelValidator.ValidateDeleteAsync(productID));
			if (response.Success)
			{
				await this.productRepository.Delete(productID);
			}

			return response;
		}

		public async Task<ApiProductResponseModel> ByName(string name)
		{
			Product record = await this.productRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiProductResponseModel> ByProductNumber(string productNumber)
		{
			Product record = await this.productRepository.ByProductNumber(productNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterials(int componentID, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.productRepository.BillOfMaterials(componentID, limit, offset);

			return this.bolBillOfMaterialMapper.MapBOToModel(this.dalBillOfMaterialMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductCostHistoryResponseModel>> ProductCostHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductCostHistory> records = await this.productRepository.ProductCostHistories(productID, limit, offset);

			return this.bolProductCostHistoryMapper.MapBOToModel(this.dalProductCostHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductInventoryResponseModel>> ProductInventories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductInventory> records = await this.productRepository.ProductInventories(productID, limit, offset);

			return this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductListPriceHistoryResponseModel>> ProductListPriceHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductListPriceHistory> records = await this.productRepository.ProductListPriceHistories(productID, limit, offset);

			return this.bolProductListPriceHistoryMapper.MapBOToModel(this.dalProductListPriceHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoes(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductProductPhoto> records = await this.productRepository.ProductProductPhotoes(productID, limit, offset);

			return this.bolProductProductPhotoMapper.MapBOToModel(this.dalProductProductPhotoMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductReviewResponseModel>> ProductReviews(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductReview> records = await this.productRepository.ProductReviews(productID, limit, offset);

			return this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTransactionHistoryResponseModel>> TransactionHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<TransactionHistory> records = await this.productRepository.TransactionHistories(productID, limit, offset);

			return this.bolTransactionHistoryMapper.MapBOToModel(this.dalTransactionHistoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiWorkOrderResponseModel>> WorkOrders(int productID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrder> records = await this.productRepository.WorkOrders(productID, limit, offset);

			return this.bolWorkOrderMapper.MapBOToModel(this.dalWorkOrderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d0d9122ede58ed922d01655cac69c1d9</Hash>
</Codenesium>*/