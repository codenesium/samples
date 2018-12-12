using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractEfmigrationshistoryService : AbstractService
	{
		protected IEfmigrationshistoryRepository EfmigrationshistoryRepository { get; private set; }

		protected IApiEfmigrationshistoryServerRequestModelValidator EfmigrationshistoryModelValidator { get; private set; }

		protected IBOLEfmigrationshistoryMapper BolEfmigrationshistoryMapper { get; private set; }

		protected IDALEfmigrationshistoryMapper DalEfmigrationshistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractEfmigrationshistoryService(
			ILogger logger,
			IEfmigrationshistoryRepository efmigrationshistoryRepository,
			IApiEfmigrationshistoryServerRequestModelValidator efmigrationshistoryModelValidator,
			IBOLEfmigrationshistoryMapper bolEfmigrationshistoryMapper,
			IDALEfmigrationshistoryMapper dalEfmigrationshistoryMapper)
			: base()
		{
			this.EfmigrationshistoryRepository = efmigrationshistoryRepository;
			this.EfmigrationshistoryModelValidator = efmigrationshistoryModelValidator;
			this.BolEfmigrationshistoryMapper = bolEfmigrationshistoryMapper;
			this.DalEfmigrationshistoryMapper = dalEfmigrationshistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEfmigrationshistoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EfmigrationshistoryRepository.All(limit, offset);

			return this.BolEfmigrationshistoryMapper.MapBOToModel(this.DalEfmigrationshistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEfmigrationshistoryServerResponseModel> Get(string migrationId)
		{
			var record = await this.EfmigrationshistoryRepository.Get(migrationId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEfmigrationshistoryMapper.MapBOToModel(this.DalEfmigrationshistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEfmigrationshistoryServerResponseModel>> Create(
			ApiEfmigrationshistoryServerRequestModel model)
		{
			CreateResponse<ApiEfmigrationshistoryServerResponseModel> response = ValidationResponseFactory<ApiEfmigrationshistoryServerResponseModel>.CreateResponse(await this.EfmigrationshistoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolEfmigrationshistoryMapper.MapModelToBO(default(string), model);
				var record = await this.EfmigrationshistoryRepository.Create(this.DalEfmigrationshistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEfmigrationshistoryMapper.MapBOToModel(this.DalEfmigrationshistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEfmigrationshistoryServerResponseModel>> Update(
			string migrationId,
			ApiEfmigrationshistoryServerRequestModel model)
		{
			var validationResult = await this.EfmigrationshistoryModelValidator.ValidateUpdateAsync(migrationId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEfmigrationshistoryMapper.MapModelToBO(migrationId, model);
				await this.EfmigrationshistoryRepository.Update(this.DalEfmigrationshistoryMapper.MapBOToEF(bo));

				var record = await this.EfmigrationshistoryRepository.Get(migrationId);

				return ValidationResponseFactory<ApiEfmigrationshistoryServerResponseModel>.UpdateResponse(this.BolEfmigrationshistoryMapper.MapBOToModel(this.DalEfmigrationshistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiEfmigrationshistoryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string migrationId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.EfmigrationshistoryModelValidator.ValidateDeleteAsync(migrationId));

			if (response.Success)
			{
				await this.EfmigrationshistoryRepository.Delete(migrationId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fdbe6679594e1e860653da4c41681459</Hash>
</Codenesium>*/