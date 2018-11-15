using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesPersonService : AbstractService
	{
		protected ISalesPersonRepository SalesPersonRepository { get; private set; }

		protected IApiSalesPersonServerRequestModelValidator SalesPersonModelValidator { get; private set; }

		protected IBOLSalesPersonMapper BolSalesPersonMapper { get; private set; }

		protected IDALSalesPersonMapper DalSalesPersonMapper { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		protected IBOLStoreMapper BolStoreMapper { get; private set; }

		protected IDALStoreMapper DalStoreMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesPersonService(
			ILogger logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonServerRequestModelValidator salesPersonModelValidator,
			IBOLSalesPersonMapper bolSalesPersonMapper,
			IDALSalesPersonMapper dalSalesPersonMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLStoreMapper bolStoreMapper,
			IDALStoreMapper dalStoreMapper)
			: base()
		{
			this.SalesPersonRepository = salesPersonRepository;
			this.SalesPersonModelValidator = salesPersonModelValidator;
			this.BolSalesPersonMapper = bolSalesPersonMapper;
			this.DalSalesPersonMapper = dalSalesPersonMapper;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.BolStoreMapper = bolStoreMapper;
			this.DalStoreMapper = dalStoreMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesPersonRepository.All(limit, offset);

			return this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesPersonServerResponseModel> Get(int businessEntityID)
		{
			var record = await this.SalesPersonRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesPersonServerResponseModel>> Create(
			ApiSalesPersonServerRequestModel model)
		{
			CreateResponse<ApiSalesPersonServerResponseModel> response = ValidationResponseFactory<ApiSalesPersonServerResponseModel>.CreateResponse(await this.SalesPersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSalesPersonMapper.MapModelToBO(default(int), model);
				var record = await this.SalesPersonRepository.Create(this.DalSalesPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesPersonServerResponseModel>> Update(
			int businessEntityID,
			ApiSalesPersonServerRequestModel model)
		{
			var validationResult = await this.SalesPersonModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesPersonMapper.MapModelToBO(businessEntityID, model);
				await this.SalesPersonRepository.Update(this.DalSalesPersonMapper.MapBOToEF(bo));

				var record = await this.SalesPersonRepository.Get(businessEntityID);

				return ValidationResponseFactory<ApiSalesPersonServerResponseModel>.UpdateResponse(this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiSalesPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SalesPersonModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.SalesPersonRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async virtual Task<ApiSalesPersonServerResponseModel> ByRowguid(Guid rowguid)
		{
			SalesPerson record = await this.SalesPersonRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesPersonMapper.MapBOToModel(this.DalSalesPersonMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.SalesPersonRepository.SalesOrderHeadersBySalesPersonID(salesPersonID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiStoreServerResponseModel>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			List<Store> records = await this.SalesPersonRepository.StoresBySalesPersonID(salesPersonID, limit, offset);

			return this.BolStoreMapper.MapBOToModel(this.DalStoreMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5e7d2191c688a3449a36898b7eced1d6</Hash>
</Codenesium>*/