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
	public abstract class AbstractDatabaseLogService : AbstractService
	{
		protected IDatabaseLogRepository DatabaseLogRepository { get; private set; }

		protected IApiDatabaseLogRequestModelValidator DatabaseLogModelValidator { get; private set; }

		protected IBOLDatabaseLogMapper BolDatabaseLogMapper { get; private set; }

		protected IDALDatabaseLogMapper DalDatabaseLogMapper { get; private set; }

		private ILogger logger;

		public AbstractDatabaseLogService(
			ILogger logger,
			IDatabaseLogRepository databaseLogRepository,
			IApiDatabaseLogRequestModelValidator databaseLogModelValidator,
			IBOLDatabaseLogMapper bolDatabaseLogMapper,
			IDALDatabaseLogMapper dalDatabaseLogMapper)
			: base()
		{
			this.DatabaseLogRepository = databaseLogRepository;
			this.DatabaseLogModelValidator = databaseLogModelValidator;
			this.BolDatabaseLogMapper = bolDatabaseLogMapper;
			this.DalDatabaseLogMapper = dalDatabaseLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDatabaseLogResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DatabaseLogRepository.All(limit, offset);

			return this.BolDatabaseLogMapper.MapBOToModel(this.DalDatabaseLogMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDatabaseLogResponseModel> Get(int databaseLogID)
		{
			var record = await this.DatabaseLogRepository.Get(databaseLogID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDatabaseLogMapper.MapBOToModel(this.DalDatabaseLogMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDatabaseLogResponseModel>> Create(
			ApiDatabaseLogRequestModel model)
		{
			CreateResponse<ApiDatabaseLogResponseModel> response = new CreateResponse<ApiDatabaseLogResponseModel>(await this.DatabaseLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDatabaseLogMapper.MapModelToBO(default(int), model);
				var record = await this.DatabaseLogRepository.Create(this.DalDatabaseLogMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDatabaseLogMapper.MapBOToModel(this.DalDatabaseLogMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDatabaseLogResponseModel>> Update(
			int databaseLogID,
			ApiDatabaseLogRequestModel model)
		{
			var validationResult = await this.DatabaseLogModelValidator.ValidateUpdateAsync(databaseLogID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDatabaseLogMapper.MapModelToBO(databaseLogID, model);
				await this.DatabaseLogRepository.Update(this.DalDatabaseLogMapper.MapBOToEF(bo));

				var record = await this.DatabaseLogRepository.Get(databaseLogID);

				return new UpdateResponse<ApiDatabaseLogResponseModel>(this.BolDatabaseLogMapper.MapBOToModel(this.DalDatabaseLogMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDatabaseLogResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int databaseLogID)
		{
			ActionResponse response = new ActionResponse(await this.DatabaseLogModelValidator.ValidateDeleteAsync(databaseLogID));
			if (response.Success)
			{
				await this.DatabaseLogRepository.Delete(databaseLogID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>26be80b7cc7023a7aa593e276e036614</Hash>
</Codenesium>*/