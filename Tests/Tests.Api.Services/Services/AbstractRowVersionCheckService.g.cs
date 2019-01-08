using MediatR;
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
		private IMediator mediator;

		protected IRowVersionCheckRepository RowVersionCheckRepository { get; private set; }

		protected IApiRowVersionCheckServerRequestModelValidator RowVersionCheckModelValidator { get; private set; }

		protected IBOLRowVersionCheckMapper BolRowVersionCheckMapper { get; private set; }

		protected IDALRowVersionCheckMapper DalRowVersionCheckMapper { get; private set; }

		private ILogger logger;

		public AbstractRowVersionCheckService(
			ILogger logger,
			IMediator mediator,
			IRowVersionCheckRepository rowVersionCheckRepository,
			IApiRowVersionCheckServerRequestModelValidator rowVersionCheckModelValidator,
			IBOLRowVersionCheckMapper bolRowVersionCheckMapper,
			IDALRowVersionCheckMapper dalRowVersionCheckMapper)
			: base()
		{
			this.RowVersionCheckRepository = rowVersionCheckRepository;
			this.RowVersionCheckModelValidator = rowVersionCheckModelValidator;
			this.BolRowVersionCheckMapper = bolRowVersionCheckMapper;
			this.DalRowVersionCheckMapper = dalRowVersionCheckMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiRowVersionCheckServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.RowVersionCheckRepository.All(limit, offset);

			return this.BolRowVersionCheckMapper.MapBOToModel(this.DalRowVersionCheckMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiRowVersionCheckServerResponseModel> Get(int id)
		{
			var record = await this.RowVersionCheckRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolRowVersionCheckMapper.MapBOToModel(this.DalRowVersionCheckMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiRowVersionCheckServerResponseModel>> Create(
			ApiRowVersionCheckServerRequestModel model)
		{
			CreateResponse<ApiRowVersionCheckServerResponseModel> response = ValidationResponseFactory<ApiRowVersionCheckServerResponseModel>.CreateResponse(await this.RowVersionCheckModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolRowVersionCheckMapper.MapModelToBO(default(int), model);
				var record = await this.RowVersionCheckRepository.Create(this.DalRowVersionCheckMapper.MapBOToEF(bo));

				var businessObject = this.DalRowVersionCheckMapper.MapEFToBO(record);
				response.SetRecord(this.BolRowVersionCheckMapper.MapBOToModel(businessObject));
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
				var bo = this.BolRowVersionCheckMapper.MapModelToBO(id, model);
				await this.RowVersionCheckRepository.Update(this.DalRowVersionCheckMapper.MapBOToEF(bo));

				var record = await this.RowVersionCheckRepository.Get(id);

				var businessObject = this.DalRowVersionCheckMapper.MapEFToBO(record);
				var apiModel = this.BolRowVersionCheckMapper.MapBOToModel(businessObject);
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
    <Hash>447d38348132676dd4e2ad572d76431b</Hash>
</Codenesium>*/