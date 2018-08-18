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
		protected IShiftRepository ShiftRepository { get; private set; }

		protected IApiShiftRequestModelValidator ShiftModelValidator { get; private set; }

		protected IBOLShiftMapper BolShiftMapper { get; private set; }

		protected IDALShiftMapper DalShiftMapper { get; private set; }

		protected IBOLEmployeeDepartmentHistoryMapper BolEmployeeDepartmentHistoryMapper { get; private set; }

		protected IDALEmployeeDepartmentHistoryMapper DalEmployeeDepartmentHistoryMapper { get; private set; }

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
			this.ShiftRepository = shiftRepository;
			this.ShiftModelValidator = shiftModelValidator;
			this.BolShiftMapper = bolShiftMapper;
			this.DalShiftMapper = dalShiftMapper;
			this.BolEmployeeDepartmentHistoryMapper = bolEmployeeDepartmentHistoryMapper;
			this.DalEmployeeDepartmentHistoryMapper = dalEmployeeDepartmentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShiftResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ShiftRepository.All(limit, offset);

			return this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShiftResponseModel> Get(int shiftID)
		{
			var record = await this.ShiftRepository.Get(shiftID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiShiftResponseModel>> Create(
			ApiShiftRequestModel model)
		{
			CreateResponse<ApiShiftResponseModel> response = new CreateResponse<ApiShiftResponseModel>(await this.ShiftModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolShiftMapper.MapModelToBO(default(int), model);
				var record = await this.ShiftRepository.Create(this.DalShiftMapper.MapBOToEF(bo));

				response.SetRecord(this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiShiftResponseModel>> Update(
			int shiftID,
			ApiShiftRequestModel model)
		{
			var validationResult = await this.ShiftModelValidator.ValidateUpdateAsync(shiftID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolShiftMapper.MapModelToBO(shiftID, model);
				await this.ShiftRepository.Update(this.DalShiftMapper.MapBOToEF(bo));

				var record = await this.ShiftRepository.Get(shiftID);

				return new UpdateResponse<ApiShiftResponseModel>(this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiShiftResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int shiftID)
		{
			ActionResponse response = new ActionResponse(await this.ShiftModelValidator.ValidateDeleteAsync(shiftID));
			if (response.Success)
			{
				await this.ShiftRepository.Delete(shiftID);
			}

			return response;
		}

		public async Task<ApiShiftResponseModel> ByName(string name)
		{
			Shift record = await this.ShiftRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(record));
			}
		}

		public async Task<ApiShiftResponseModel> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime)
		{
			Shift record = await this.ShiftRepository.ByStartTimeEndTime(startTime, endTime);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistories(int shiftID, int limit = int.MaxValue, int offset = 0)
		{
			List<EmployeeDepartmentHistory> records = await this.ShiftRepository.EmployeeDepartmentHistories(shiftID, limit, offset);

			return this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4e2163903da31e08aab4a7eae845024d</Hash>
</Codenesium>*/