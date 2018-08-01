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
	public abstract class AbstractShiftService : AbstractService
	{
		private IShiftRepository shiftRepository;

		private IApiShiftRequestModelValidator shiftModelValidator;

		private IBOLShiftMapper bolShiftMapper;

		private IDALShiftMapper dalShiftMapper;

		private IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper;

		private IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper;

		private ILogger logger;

		public AbstractShiftService(
			ILogger logger,
			IShiftRepository shiftRepository,
			IApiShiftRequestModelValidator shiftModelValidator,
			IBOLShiftMapper bolShiftMapper,
			IDALShiftMapper dalShiftMapper,
			IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper)
			: base()
		{
			this.shiftRepository = shiftRepository;
			this.shiftModelValidator = shiftModelValidator;
			this.bolShiftMapper = bolShiftMapper;
			this.dalShiftMapper = dalShiftMapper;
			this.bolEmployeeDepartmentHistoryMapper = bolEmployeeDepartmentHistoryMapper;
			this.dalEmployeeDepartmentHistoryMapper = dalEmployeeDepartmentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShiftResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.shiftRepository.All(limit, offset);

			return this.bolShiftMapper.MapBOToModel(this.dalShiftMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShiftResponseModel> Get(int shiftID)
		{
			var record = await this.shiftRepository.Get(shiftID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolShiftMapper.MapBOToModel(this.dalShiftMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiShiftResponseModel>> Create(
			ApiShiftRequestModel model)
		{
			CreateResponse<ApiShiftResponseModel> response = new CreateResponse<ApiShiftResponseModel>(await this.shiftModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolShiftMapper.MapModelToBO(default(int), model);
				var record = await this.shiftRepository.Create(this.dalShiftMapper.MapBOToEF(bo));

				response.SetRecord(this.bolShiftMapper.MapBOToModel(this.dalShiftMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiShiftResponseModel>> Update(
			int shiftID,
			ApiShiftRequestModel model)
		{
			var validationResult = await this.shiftModelValidator.ValidateUpdateAsync(shiftID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolShiftMapper.MapModelToBO(shiftID, model);
				await this.shiftRepository.Update(this.dalShiftMapper.MapBOToEF(bo));

				var record = await this.shiftRepository.Get(shiftID);

				return new UpdateResponse<ApiShiftResponseModel>(this.bolShiftMapper.MapBOToModel(this.dalShiftMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiShiftResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int shiftID)
		{
			ActionResponse response = new ActionResponse(await this.shiftModelValidator.ValidateDeleteAsync(shiftID));
			if (response.Success)
			{
				await this.shiftRepository.Delete(shiftID);
			}

			return response;
		}

		public async Task<ApiShiftResponseModel> ByName(string name)
		{
			Shift record = await this.shiftRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolShiftMapper.MapBOToModel(this.dalShiftMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiShiftResponseModel> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime)
		{
			Shift record = await this.shiftRepository.ByStartTimeEndTime(startTime, endTime);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolShiftMapper.MapBOToModel(this.dalShiftMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int shiftID, int limit = int.MaxValue, int offset = 0)
		{
			List<EmployeeDepartmentHistory> records = await this.shiftRepository.EmployeeDepartmentHistories(shiftID, limit, offset);

			return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2a4f7aee5811b75281ea1378da216fb2</Hash>
</Codenesium>*/