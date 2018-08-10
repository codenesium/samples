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
	public abstract class AbstractEmployeePayHistoryService : AbstractService
	{
		protected IEmployeePayHistoryRepository EmployeePayHistoryRepository { get; private set; }

		protected IApiEmployeePayHistoryRequestModelValidator EmployeePayHistoryModelValidator { get; private set; }

		protected IBOLEmployeePayHistoryMapper BolEmployeePayHistoryMapper { get; private set; }

		protected IDALEmployeePayHistoryMapper DalEmployeePayHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractEmployeePayHistoryService(
			ILogger logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IApiEmployeePayHistoryRequestModelValidator employeePayHistoryModelValidator,
			IBOLEmployeePayHistoryMapper bolEmployeePayHistoryMapper,
			IDALEmployeePayHistoryMapper dalEmployeePayHistoryMapper)
			: base()
		{
			this.EmployeePayHistoryRepository = employeePayHistoryRepository;
			this.EmployeePayHistoryModelValidator = employeePayHistoryModelValidator;
			this.BolEmployeePayHistoryMapper = bolEmployeePayHistoryMapper;
			this.DalEmployeePayHistoryMapper = dalEmployeePayHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEmployeePayHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EmployeePayHistoryRepository.All(limit, offset);

			return this.BolEmployeePayHistoryMapper.MapBOToModel(this.DalEmployeePayHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEmployeePayHistoryResponseModel> Get(int businessEntityID)
		{
			var record = await this.EmployeePayHistoryRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEmployeePayHistoryMapper.MapBOToModel(this.DalEmployeePayHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEmployeePayHistoryResponseModel>> Create(
			ApiEmployeePayHistoryRequestModel model)
		{
			CreateResponse<ApiEmployeePayHistoryResponseModel> response = new CreateResponse<ApiEmployeePayHistoryResponseModel>(await this.EmployeePayHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEmployeePayHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.EmployeePayHistoryRepository.Create(this.DalEmployeePayHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEmployeePayHistoryMapper.MapBOToModel(this.DalEmployeePayHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEmployeePayHistoryResponseModel>> Update(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel model)
		{
			var validationResult = await this.EmployeePayHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEmployeePayHistoryMapper.MapModelToBO(businessEntityID, model);
				await this.EmployeePayHistoryRepository.Update(this.DalEmployeePayHistoryMapper.MapBOToEF(bo));

				var record = await this.EmployeePayHistoryRepository.Get(businessEntityID);

				return new UpdateResponse<ApiEmployeePayHistoryResponseModel>(this.BolEmployeePayHistoryMapper.MapBOToModel(this.DalEmployeePayHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEmployeePayHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.EmployeePayHistoryModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.EmployeePayHistoryRepository.Delete(businessEntityID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9f726bf7d6b6738fa57b85562b8c7a6d</Hash>
</Codenesium>*/