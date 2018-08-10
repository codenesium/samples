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
		protected IEmployeeDepartmentHistoryRepository EmployeeDepartmentHistoryRepository { get; private set; }

		protected IApiEmployeeDepartmentHistoryRequestModelValidator EmployeeDepartmentHistoryModelValidator { get; private set; }

		protected IBOLEmployeeDepartmentHistoryMapper BolEmployeeDepartmentHistoryMapper { get; private set; }

		protected IDALEmployeeDepartmentHistoryMapper DalEmployeeDepartmentHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractEmployeeDepartmentHistoryService(
			ILogger logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IApiEmployeeDepartmentHistoryRequestModelValidator employeeDepartmentHistoryModelValidator,
			IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper)
			: base()
		{
			this.EmployeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
			this.EmployeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
			this.BolEmployeeDepartmentHistoryMapper = bolEmployeeDepartmentHistoryMapper;
			this.DalEmployeeDepartmentHistoryMapper = dalEmployeeDepartmentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EmployeeDepartmentHistoryRepository.All(limit, offset);

			return this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeeDepartmentHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await this.EmployeeDepartmentHistoryRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Create(
			ApiEmployeeDepartmentHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeeDepartmentHistoryResponseModel> response = new CreateResponse<ApiEmployeeDepartmentHistoryResponseModel>(await this.EmployeeDepartmentHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEmployeeDepartmentHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.EmployeeDepartmentHistoryRepository.Create(this.DalEmployeeDepartmentHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>> Update(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel model)
		{
			var validationResult = await this.EmployeeDepartmentHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEmployeeDepartmentHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.EmployeeDepartmentHistoryRepository.Update(this.DalEmployeeDepartmentHistoryMapper.MapBOToEF(bo));

				var record = await this.EmployeeDepartmentHistoryRepository.Get(businessEntityID);

				return new UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>(this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEmployeeDepartmentHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.EmployeeDepartmentHistoryModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.EmployeeDepartmentHistoryRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByDepartmentID(short departmentID)
		{
			List<EmployeeDepartmentHistory> records = await this.EmployeeDepartmentHistoryRepository.ByDepartmentID(departmentID);

			return this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEmployeeDepartmentHistoryResponseModel>> ByShiftID(int shiftID)
		{
			List<EmployeeDepartmentHistory> records = await this.EmployeeDepartmentHistoryRepository.ByShiftID(shiftID);

			return this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>be6fb5e82922e4177972d117d239718d</Hash>
</Codenesium>*/