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

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesOrderHeaderService(
			ILogger logger,
			IMediator mediator,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderServerRequestModelValidator salesOrderHeaderModelValidator,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.SalesOrderHeaderRepository = salesOrderHeaderRepository;
			this.SalesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSalesOrderHeaderServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.SalesOrderHeaderRepository.All(limit, offset, query);

			return this.DalSalesOrderHeaderMapper.MapBOToModel(records);
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
				return this.DalSalesOrderHeaderMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderServerResponseModel>> Create(
			ApiSalesOrderHeaderServerRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderServerResponseModel> response = ValidationResponseFactory<ApiSalesOrderHeaderServerResponseModel>.CreateResponse(await this.SalesOrderHeaderModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalSalesOrderHeaderMapper.MapModelToBO(default(int), model);
				var record = await this.SalesOrderHeaderRepository.Create(bo);

				response.SetRecord(this.DalSalesOrderHeaderMapper.MapBOToModel(record));
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
				var bo = this.DalSalesOrderHeaderMapper.MapModelToBO(salesOrderID, model);
				await this.SalesOrderHeaderRepository.Update(bo);

				var record = await this.SalesOrderHeaderRepository.Get(salesOrderID);

				var apiModel = this.DalSalesOrderHeaderMapper.MapBOToModel(record);
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
				return this.DalSalesOrderHeaderMapper.MapBOToModel(record);
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
				return this.DalSalesOrderHeaderMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> ByCustomerID(int customerID, int limit = 0, int offset = int.MaxValue)
		{
			List<SalesOrderHeader> records = await this.SalesOrderHeaderRepository.ByCustomerID(customerID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> BySalesPersonID(int? salesPersonID, int limit = 0, int offset = int.MaxValue)
		{
			List<SalesOrderHeader> records = await this.SalesOrderHeaderRepository.BySalesPersonID(salesPersonID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>bf26d67163afc80bf6a97e81abba281f</Hash>
</Codenesium>*/