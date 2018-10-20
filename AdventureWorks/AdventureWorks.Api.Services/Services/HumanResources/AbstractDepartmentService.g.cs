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
	public abstract class AbstractDepartmentService : AbstractService
	{
		protected IDepartmentRepository DepartmentRepository { get; private set; }

		protected IApiDepartmentRequestModelValidator DepartmentModelValidator { get; private set; }

		protected IBOLDepartmentMapper BolDepartmentMapper { get; private set; }

		protected IDALDepartmentMapper DalDepartmentMapper { get; private set; }

		protected IBOLEmployeeDepartmentHistoryMapper BolEmployeeDepartmentHistoryMapper { get; private set; }

		protected IDALEmployeeDepartmentHistoryMapper DalEmployeeDepartmentHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractDepartmentService(
			ILogger logger,
			IDepartmentRepository departmentRepository,
			IApiDepartmentRequestModelValidator departmentModelValidator,
			IBOLDepartmentMapper bolDepartmentMapper,
			IDALDepartmentMapper dalDepartmentMapper,
			IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper)
			: base()
		{
			this.DepartmentRepository = departmentRepository;
			this.DepartmentModelValidator = departmentModelValidator;
			this.BolDepartmentMapper = bolDepartmentMapper;
			this.DalDepartmentMapper = dalDepartmentMapper;
			this.BolEmployeeDepartmentHistoryMapper = bolEmployeeDepartmentHistoryMapper;
			this.DalEmployeeDepartmentHistoryMapper = dalEmployeeDepartmentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDepartmentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DepartmentRepository.All(limit, offset);

			return this.BolDepartmentMapper.MapBOToModel(this.DalDepartmentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDepartmentResponseModel> Get(short departmentID)
		{
			var record = await this.DepartmentRepository.Get(departmentID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDepartmentMapper.MapBOToModel(this.DalDepartmentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDepartmentResponseModel>> Create(
			ApiDepartmentRequestModel model)
		{
			CreateResponse<ApiDepartmentResponseModel> response = new CreateResponse<ApiDepartmentResponseModel>(await this.DepartmentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDepartmentMapper.MapModelToBO(default(short), model);
				var record = await this.DepartmentRepository.Create(this.DalDepartmentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDepartmentMapper.MapBOToModel(this.DalDepartmentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDepartmentResponseModel>> Update(
			short departmentID,
			ApiDepartmentRequestModel model)
		{
			var validationResult = await this.DepartmentModelValidator.ValidateUpdateAsync(departmentID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDepartmentMapper.MapModelToBO(departmentID, model);
				await this.DepartmentRepository.Update(this.DalDepartmentMapper.MapBOToEF(bo));

				var record = await this.DepartmentRepository.Get(departmentID);

				return new UpdateResponse<ApiDepartmentResponseModel>(this.BolDepartmentMapper.MapBOToModel(this.DalDepartmentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDepartmentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			short departmentID)
		{
			ActionResponse response = new ActionResponse(await this.DepartmentModelValidator.ValidateDeleteAsync(departmentID));
			if (response.Success)
			{
				await this.DepartmentRepository.Delete(departmentID);
			}

			return response;
		}

		public async Task<ApiDepartmentResponseModel> ByName(string name)
		{
			Department record = await this.DepartmentRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDepartmentMapper.MapBOToModel(this.DalDepartmentMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiEmployeeDepartmentHistoryResponseModel>> EmployeeDepartmentHistoriesByDepartmentID(short departmentID, int limit = int.MaxValue, int offset = 0)
		{
			List<EmployeeDepartmentHistory> records = await this.DepartmentRepository.EmployeeDepartmentHistoriesByDepartmentID(departmentID, limit, offset);

			return this.BolEmployeeDepartmentHistoryMapper.MapBOToModel(this.DalEmployeeDepartmentHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>0891f1142a3846c4e9978c6e1cd73024</Hash>
</Codenesium>*/