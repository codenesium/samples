using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractLinkLogService : AbstractService
	{
		private IMediator mediator;

		protected ILinkLogRepository LinkLogRepository { get; private set; }

		protected IApiLinkLogServerRequestModelValidator LinkLogModelValidator { get; private set; }

		protected IBOLLinkLogMapper BolLinkLogMapper { get; private set; }

		protected IDALLinkLogMapper DalLinkLogMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkLogService(
			ILogger logger,
			IMediator mediator,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogServerRequestModelValidator linkLogModelValidator,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base()
		{
			this.LinkLogRepository = linkLogRepository;
			this.LinkLogModelValidator = linkLogModelValidator;
			this.BolLinkLogMapper = bolLinkLogMapper;
			this.DalLinkLogMapper = dalLinkLogMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLinkLogServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkLogRepository.All(limit, offset);

			return this.BolLinkLogMapper.MapBOToModel(this.DalLinkLogMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkLogServerResponseModel> Get(int id)
		{
			var record = await this.LinkLogRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkLogMapper.MapBOToModel(this.DalLinkLogMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkLogServerResponseModel>> Create(
			ApiLinkLogServerRequestModel model)
		{
			CreateResponse<ApiLinkLogServerResponseModel> response = ValidationResponseFactory<ApiLinkLogServerResponseModel>.CreateResponse(await this.LinkLogModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolLinkLogMapper.MapModelToBO(default(int), model);
				var record = await this.LinkLogRepository.Create(this.DalLinkLogMapper.MapBOToEF(bo));

				var businessObject = this.DalLinkLogMapper.MapEFToBO(record);
				response.SetRecord(this.BolLinkLogMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new LinkLogCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkLogServerResponseModel>> Update(
			int id,
			ApiLinkLogServerRequestModel model)
		{
			var validationResult = await this.LinkLogModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLinkLogMapper.MapModelToBO(id, model);
				await this.LinkLogRepository.Update(this.DalLinkLogMapper.MapBOToEF(bo));

				var record = await this.LinkLogRepository.Get(id);

				var businessObject = this.DalLinkLogMapper.MapEFToBO(record);
				var apiModel = this.BolLinkLogMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new LinkLogUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiLinkLogServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiLinkLogServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LinkLogModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.LinkLogRepository.Delete(id);

				await this.mediator.Publish(new LinkLogDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1db1572218d1165b28a55bcb640a1c77</Hash>
</Codenesium>*/