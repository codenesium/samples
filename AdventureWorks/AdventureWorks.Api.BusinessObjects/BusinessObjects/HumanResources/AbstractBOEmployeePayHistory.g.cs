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
	public abstract class AbstractBOEmployeePayHistory: AbstractBOManager
	{
		private IEmployeePayHistoryRepository employeePayHistoryRepository;
		private IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator;
		private IBOLEmployeePayHistoryMapper employeePayHistoryMapper;
		private ILogger logger;

		public AbstractBOEmployeePayHistory(
			ILogger logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
			IBOLEmployeePayHistoryMapper employeePayHistoryMapper)
			: base()

		{
			this.employeePayHistoryRepository = employeePayHistoryRepository;
			this.employeePayHistoryModelValidator = employeePayHistoryModelValidator;
			this.employeePayHistoryMapper = employeePayHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.employeePayHistoryRepository.All(skip, take, orderClause);

			return this.employeePayHistoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiEmployeePayHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await employeePayHistoryRepository.Get(businessEntityID);

			return this.employeePayHistoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiEmployeePayHistoryResponseModel>> Create(
			ApiEmployeePayHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeePayHistoryResponseModel> response = new CreateResponse<ApiEmployeePayHistoryResponseModel>(await this.employeePayHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.employeePayHistoryMapper.MapModelToDTO(default (int), model);
				var record = await this.employeePayHistoryRepository.Create(dto);

				response.SetRecord(this.employeePayHistoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeePayHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.employeePayHistoryMapper.MapModelToDTO(businessEntityID, model);
				await this.employeePayHistoryRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeePayHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.employeePayHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d258a85587aa52ca31a3ac362850597e</Hash>
</Codenesium>*/