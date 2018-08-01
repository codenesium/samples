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
	public abstract class AbstractEmployeeDepartmentHistoryService : AbstractService
	{
		private IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;

		private IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator;

		private IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper;

		private IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper;

		private ILogger logger;

		public AbstractEmployeeDepartmentHistoryService(
			ILogger logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
			IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper)
			: base()
		{
			this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
			this.employeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
			this.bolEmployeeDepartmentHistoryMapper = bolEmployeeDepartmentHistoryMapper;
			this.dalEmployeeDepartmentHistoryMapper = dalEmployeeDepartmentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.employeeDepartmentHistoryRepository.All(limit, offset);

			return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await this.employeeDepartmentHistoryRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Create(
			ApiEmployeeDepartmentHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> response = new CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>(await this.employeeDepartmentHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolEmployeeDepartmentHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.employeeDepartmentHistoryRepository.Create(this.dalEmployeeDepartmentHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Update(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel model)
		{
			var validationResult = await this.employeeDepartmentHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolEmployeeDepartmentHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.employeeDepartmentHistoryRepository.Update(this.dalEmployeeDepartmentHistoryMapper.MapBOToEF(bo));

				var record = await this.employeeDepartmentHistoryRepository.Get(businessEntityID);

				return new UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>(this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>(validationResult);
			}
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

		public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByDepartmentID(short departmentID)
		{
			List<EmployeeDepartmentHistory> records = await this.employeeDepartmentHistoryRepository.ByDepartmentID(departmentID);

			return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByShiftID(int shiftID)
		{
			List<EmployeeDepartmentHistory> records = await this.employeeDepartmentHistoryRepository.ByShiftID(shiftID);

			return this.bolEmployeeDepartmentHistoryMapper.MapBOToModel(this.dalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b5deb7edde6e3b84f16bc82e17e5fcb9</Hash>
</Codenesium>*/