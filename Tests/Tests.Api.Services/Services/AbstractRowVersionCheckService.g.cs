using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractRowVersionCheckService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IRowVersionCheckRepository RowVersionCheckRepository { get; private set; }

		protected IApiRowVersionCheckServerRequestModelValidator RowVersionCheckModelValidator { get; private set; }

		protected IDALRowVersionCheckMapper DalRowVersionCheckMapper { get; private set; }

		private ILogger logger;

		public AbstractRowVersionCheckService(
			ILogger logger,
			MediatR.IMediator mediator,
			IRowVersionCheckRepository rowVersionCheckRepository,
			IApiRowVersionCheckServerRequestModelValidator rowVersionCheckModelValidator,
			IDALRowVersionCheckMapper dalRowVersionCheckMapper)
			: base()
		{
			this.RowVersionCheckRepository = rowVersionCheckRepository;
			this.RowVersionCheckModelValidator = rowVersionCheckModelValidator;
			this.DalRowVersionCheckMapper = dalRowVersionCheckMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiRowVersionCheckServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<RowVersionCheck> records = await this.RowVersionCheckRepository.All(limit, offset, query);

			return this.DalRowVersionCheckMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiRowVersionCheckServerResponseModel> Get(int id)
		{
			RowVersionCheck record = await this.RowVersionCheckRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalRowVersionCheckMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiRowVersionCheckServerResponseModel>> Create(
			ApiRowVersionCheckServerRequestModel model)
		{
			CreateResponse<ApiRowVersionCheckServerResponseModel> response = ValidationResponseFactory<ApiRowVersionCheckServerResponseModel>.CreateResponse(await this.RowVersionCheckModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				RowVersionCheck record = this.DalRowVersionCheckMapper.MapModelToEntity(default(int), model);
				record = await this.RowVersionCheckRepository.Create(record);

				response.SetRecord(this.DalRowVersionCheckMapper.MapEntityToModel(record));
				await this.mediator.Publish(new RowVersionCheckCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRowVersionCheckServerResponseModel>> Update(
			int id,
			ApiRowVersionCheckServerRequestModel model)
		{
			var validationResult = await this.RowVersionCheckModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				RowVersionCheck record = this.DalRowVersionCheckMapper.MapModelToEntity(id, model);
				await this.RowVersionCheckRepository.Update(record);

				record = await this.RowVersionCheckRepository.Get(id);

				ApiRowVersionCheckServerResponseModel apiModel = this.DalRowVersionCheckMapper.MapEntityToModel(record);
				await this.mediator.Publish(new RowVersionCheckUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiRowVersionCheckServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiRowVersionCheckServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.RowVersionCheckModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.RowVersionCheckRepository.Delete(id);

				await this.mediator.Publish(new RowVersionCheckDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7fa507f7a6430322cdd7af4b5ab1fd46</Hash>
</Codenesium>*/