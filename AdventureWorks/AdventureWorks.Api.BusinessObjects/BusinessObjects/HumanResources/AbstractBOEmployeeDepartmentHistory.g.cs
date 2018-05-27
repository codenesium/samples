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
	public abstract class AbstractBOEmployeeDepartmentHistory: AbstractBOManager
	{
		private IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;
		private IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator;
		private IBOLEmployeeDepartmentHistoryMapper employeeDepartmentHistoryMapper;
		private ILogger logger;

		public AbstractBOEmployeeDepartmentHistory(
			ILogger logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
			IBOLEmployeeDepartmentHistoryMapper employeeDepartmentHistoryMapper)
			: base()

		{
			this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
			this.employeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
			this.employeeDepartmentHistoryMapper = employeeDepartmentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.employeeDepartmentHistoryRepository.All(skip, take, orderClause);

			return this.employeeDepartmentHistoryMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await employeeDepartmentHistoryRepository.Get(businessEntityID);

			return this.employeeDepartmentHistoryMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Create(
			ApiEmployeeDepartmentHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> response = new CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>(await this.employeeDepartmentHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.employeeDepartmentHistoryMapper.MapModelToDTO(default (int), model);
				var record = await this.employeeDepartmentHistoryRepository.Create(dto);

				response.SetRecord(this.employeeDepartmentHistoryMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.employeeDepartmentHistoryMapper.MapModelToDTO(businessEntityID, model);
				await this.employeeDepartmentHistoryRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.employeeDepartmentHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetDepartmentID(short departmentID)
		{
			List<DTOEmployeeDepartmentHistory> records = await this.employeeDepartmentHistoryRepository.GetDepartmentID(departmentID);

			return this.employeeDepartmentHistoryMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> GetShiftID(int shiftID)
		{
			List<DTOEmployeeDepartmentHistory> records = await this.employeeDepartmentHistoryRepository.GetShiftID(shiftID);

			return this.employeeDepartmentHistoryMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>39832378152d536771e32a0222cc532d</Hash>
</Codenesium>*/