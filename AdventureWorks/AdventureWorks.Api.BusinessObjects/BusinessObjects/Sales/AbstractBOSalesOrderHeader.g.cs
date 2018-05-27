using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOSalesOrderHeader: AbstractBOManager
	{
		private ISalesOrderHeaderRepository salesOrderHeaderRepository;
		private IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator;
		private IBOLSalesOrderHeaderMapper salesOrderHeaderMapper;
		private ILogger logger;

		public AbstractBOSalesOrderHeader(
			ILogger logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper salesOrderHeaderMapper)
			: base()

		{
			this.salesOrderHeaderRepository = salesOrderHeaderRepository;
			this.salesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
			this.salesOrderHeaderMapper = salesOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesOrderHeaderRepository.All(skip, take, orderClause);

			return this.salesOrderHeaderMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> Get(int salesOrderID)
		{
			var record = await salesOrderHeaderRepository.Get(salesOrderID);

			return this.salesOrderHeaderMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderResponseModel>> Create(
			ApiSalesOrderHeaderRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderResponseModel> response = new CreateResponse<ApiSalesOrderHeaderResponseModel>(await this.salesOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesOrderHeaderMapper.MapModelToDTO(default (int), model);
				var record = await this.salesOrderHeaderRepository.Create(dto);

				response.SetRecord(this.salesOrderHeaderMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				var dto = this.salesOrderHeaderMapper.MapModelToDTO(salesOrderID, model);
				await this.salesOrderHeaderRepository.Update(salesOrderID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				await this.salesOrderHeaderRepository.Delete(salesOrderID);
			}
			return response;
		}

		public async Task<ApiSalesOrderHeaderResponseModel> GetSalesOrderNumber(string salesOrderNumber)
		{
			DTOSalesOrderHeader record = await this.salesOrderHeaderRepository.GetSalesOrderNumber(salesOrderNumber);

			return this.salesOrderHeaderMapper.MapDTOToModel(record);
		}
		public async Task<List<ApiSalesOrderHeaderResponseModel>> GetCustomerID(int customerID)
		{
			List<DTOSalesOrderHeader> records = await this.salesOrderHeaderRepository.GetCustomerID(customerID);

			return this.salesOrderHeaderMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiSalesOrderHeaderResponseModel>> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			List<DTOSalesOrderHeader> records = await this.salesOrderHeaderRepository.GetSalesPersonID(salesPersonID);

			return this.salesOrderHeaderMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>cf85bda616f5971c5f2e60068e5df095</Hash>
</Codenesium>*/