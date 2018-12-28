using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSalesOrderHeaderService : AbstractService
	{
		private IMediator mediator;

		protected ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; private set; }

		protected IApiSalesOrderHeaderServerRequestModelValidator SalesOrderHeaderModelValidator { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesOrderHeaderService(
			ILogger logger,
			IMediator mediator,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderServerRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.SalesOrderHeaderRepository = salesOrderHeaderRepository;
			this.SalesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSalesOrderHeaderServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesOrderHeaderRepository.All(limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderHeaderServerResponseModel> Get(int salesOrderID)
		{
			var record = await this.SalesOrderHeaderRepository.Get(salesOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderServerResponseModel>> Create(
			ApiSalesOrderHeaderServerRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderServerResponseModel> response = ValidationResponseFactory<ApiSalesOrderHeaderServerResponseModel>.CreateResponse(await this.SalesOrderHeaderModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSalesOrderHeaderMapper.MapModelToBO(default(int), model);
				var record = await this.SalesOrderHeaderRepository.Create(this.DalSalesOrderHeaderMapper.MapBOToEF(bo));

				var businessObject = this.DalSalesOrderHeaderMapper.MapEFToBO(record);
				response.SetRecord(this.BolSalesOrderHeaderMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new SalesOrderHeaderCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesOrderHeaderServerResponseModel>> Update(
			int salesOrderID,
			ApiSalesOrderHeaderServerRequestModel model)
		{
			var validationResult = await this.SalesOrderHeaderModelValidator.ValidateUpdateAsync(salesOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesOrderHeaderMapper.MapModelToBO(salesOrderID, model);
				await this.SalesOrderHeaderRepository.Update(this.DalSalesOrderHeaderMapper.MapBOToEF(bo));

				var record = await this.SalesOrderHeaderRepository.Get(salesOrderID);

				var businessObject = this.DalSalesOrderHeaderMapper.MapEFToBO(record);
				var apiModel = this.BolSalesOrderHeaderMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new SalesOrderHeaderUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSalesOrderHeaderServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSalesOrderHeaderServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SalesOrderHeaderModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				await this.SalesOrderHeaderRepository.Delete(salesOrderID);

				await this.mediator.Publish(new SalesOrderHeaderDeletedNotification(salesOrderID));
			}

			return response;
		}

		public async virtual Task<ApiSalesOrderHeaderServerResponseModel> ByRowguid(Guid rowguid)
		{
			SalesOrderHeader record = await this.SalesOrderHeaderRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<ApiSalesOrderHeaderServerResponseModel> BySalesOrderNumber(string salesOrderNumber)
		{
			SalesOrderHeader record = await this.SalesOrderHeaderRepository.BySalesOrderNumber(salesOrderNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> ByCustomerID(int customerID, int limit = 0, int offset = int.MaxValue)
		{
			List<SalesOrderHeader> records = await this.SalesOrderHeaderRepository.ByCustomerID(customerID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> BySalesPersonID(int? salesPersonID, int limit = 0, int offset = int.MaxValue)
		{
			List<SalesOrderHeader> records = await this.SalesOrderHeaderRepository.BySalesPersonID(salesPersonID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>77111624a4c3a55e2e910ee81d5e54d8</Hash>
</Codenesium>*/