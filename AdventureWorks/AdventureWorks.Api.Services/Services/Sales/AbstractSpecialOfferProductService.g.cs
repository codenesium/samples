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
	public abstract class AbstractSpecialOfferProductService : AbstractService
	{
		protected ISpecialOfferProductRepository SpecialOfferProductRepository { get; private set; }

		protected IApiSpecialOfferProductRequestModelValidator SpecialOfferProductModelValidator { get; private set; }

		protected IBOLSpecialOfferProductMapper BolSpecialOfferProductMapper { get; private set; }

		protected IDALSpecialOfferProductMapper DalSpecialOfferProductMapper { get; private set; }

		protected IBOLSalesOrderDetailMapper BolSalesOrderDetailMapper { get; private set; }

		protected IDALSalesOrderDetailMapper DalSalesOrderDetailMapper { get; private set; }

		private ILogger logger;

		public AbstractSpecialOfferProductService(
			ILogger logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
			IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper,
			IDALSpecialOfferProductMapper dalSpecialOfferProductMapper,
			IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalSalesOrderDetailMapper)
			: base()
		{
			this.SpecialOfferProductRepository = specialOfferProductRepository;
			this.SpecialOfferProductModelValidator = specialOfferProductModelValidator;
			this.BolSpecialOfferProductMapper = bolSpecialOfferProductMapper;
			this.DalSpecialOfferProductMapper = dalSpecialOfferProductMapper;
			this.BolSalesOrderDetailMapper = bolSalesOrderDetailMapper;
			this.DalSalesOrderDetailMapper = dalSalesOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpecialOfferProductResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpecialOfferProductRepository.All(limit, offset);

			return this.BolSpecialOfferProductMapper.MapBOToModel(this.DalSpecialOfferProductMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpecialOfferProductResponseModel> Get(int specialOfferID)
		{
			var record = await this.SpecialOfferProductRepository.Get(specialOfferID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpecialOfferProductMapper.MapBOToModel(this.DalSpecialOfferProductMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferProductResponseModel>> Create(
			ApiSpecialOfferProductRequestModel model)
		{
			CreateResponse<ApiSpecialOfferProductResponseModel> response = new CreateResponse<ApiSpecialOfferProductResponseModel>(await this.SpecialOfferProductModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSpecialOfferProductMapper.MapModelToBO(default(int), model);
				var record = await this.SpecialOfferProductRepository.Create(this.DalSpecialOfferProductMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSpecialOfferProductMapper.MapBOToModel(this.DalSpecialOfferProductMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpecialOfferProductResponseModel>> Update(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel model)
		{
			var validationResult = await this.SpecialOfferProductModelValidator.ValidateUpdateAsync(specialOfferID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSpecialOfferProductMapper.MapModelToBO(specialOfferID, model);
				await this.SpecialOfferProductRepository.Update(this.DalSpecialOfferProductMapper.MapBOToEF(bo));

				var record = await this.SpecialOfferProductRepository.Get(specialOfferID);

				return new UpdateResponse<ApiSpecialOfferProductResponseModel>(this.BolSpecialOfferProductMapper.MapBOToModel(this.DalSpecialOfferProductMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSpecialOfferProductResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = new ActionResponse(await this.SpecialOfferProductModelValidator.ValidateDeleteAsync(specialOfferID));
			if (response.Success)
			{
				await this.SpecialOfferProductRepository.Delete(specialOfferID);
			}

			return response;
		}

		public async Task<List<ApiSpecialOfferProductResponseModel>> ByProductID(int productID)
		{
			List<SpecialOfferProduct> records = await this.SpecialOfferProductRepository.ByProductID(productID);

			return this.BolSpecialOfferProductMapper.MapBOToModel(this.DalSpecialOfferProductMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int specialOfferID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderDetail> records = await this.SpecialOfferProductRepository.SalesOrderDetails(specialOfferID, limit, offset);

			return this.BolSalesOrderDetailMapper.MapBOToModel(this.DalSalesOrderDetailMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>781e904668d618819355f4f1de57b5b5</Hash>
</Codenesium>*/