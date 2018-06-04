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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractEmployeePayHistoryService: AbstractService
	{
		private IEmployeePayHistoryRepository employeePayHistoryRepository;
		private IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator;
		private IBOLEmployeePayHistoryMapper BOLEmployeePayHistoryMapper;
		private IDALEmployeePayHistoryMapper DALEmployeePayHistoryMapper;
		private ILogger logger;

		public AbstractEmployeePayHistoryService(
			ILogger logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
			IBOLEmployeePayHistoryMapper bolemployeePayHistoryMapper,
			IDALEmployeePayHistoryMapper dalemployeePayHistoryMapper)
			: base()

		{
			this.employeePayHistoryRepository = employeePayHistoryRepository;
			this.employeePayHistoryModelValidator = employeePayHistoryModelValidator;
			this.BOLEmployeePayHistoryMapper = bolemployeePayHistoryMapper;
			this.DALEmployeePayHistoryMapper = dalemployeePayHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.employeePayHistoryRepository.All(skip, take, orderClause);

			return this.BOLEmployeePayHistoryMapper.MapBOToModel(this.DALEmployeePayHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeePayHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await employeePayHistoryRepository.Get(businessEntityID);

			return this.BOLEmployeePayHistoryMapper.MapBOToModel(this.DALEmployeePayHistoryMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiEmployeePayHistoryResponseModel>> Create(
			ApiEmployeePayHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeePayHistoryResponseModel> response = new CreateResponse<ApiEmployeePayHistoryResponseModel>(await this.employeePayHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLEmployeePayHistoryMapper.MapModelToBO(default (int), model);
				var record = await this.employeePayHistoryRepository.Create(this.DALEmployeePayHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLEmployeePayHistoryMapper.MapBOToModel(this.DALEmployeePayHistoryMapper.MapEFToBO(record)));
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
				var bo = this.BOLEmployeePayHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.employeePayHistoryRepository.Update(this.DALEmployeePayHistoryMapper.MapBOToEF(bo));
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
    <Hash>2ed0df82cfd5e9e280894fef01ae403a</Hash>
</Codenesium>*/