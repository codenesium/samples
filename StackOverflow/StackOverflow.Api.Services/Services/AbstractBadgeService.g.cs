using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBadgeService : AbstractService
	{
		private IMediator mediator;

		protected IBadgeRepository BadgeRepository { get; private set; }

		protected IApiBadgeServerRequestModelValidator BadgeModelValidator { get; private set; }

		protected IBOLBadgeMapper BolBadgeMapper { get; private set; }

		protected IDALBadgeMapper DalBadgeMapper { get; private set; }

		private ILogger logger;

		public AbstractBadgeService(
			ILogger logger,
			IMediator mediator,
			IBadgeRepository badgeRepository,
			IApiBadgeServerRequestModelValidator badgeModelValidator,
			IBOLBadgeMapper bolBadgeMapper,
			IDALBadgeMapper dalBadgeMapper)
			: base()
		{
			this.BadgeRepository = badgeRepository;
			this.BadgeModelValidator = badgeModelValidator;
			this.BolBadgeMapper = bolBadgeMapper;
			this.DalBadgeMapper = dalBadgeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBadgeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BadgeRepository.All(limit, offset);

			return this.BolBadgeMapper.MapBOToModel(this.DalBadgeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBadgeServerResponseModel> Get(int id)
		{
			var record = await this.BadgeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBadgeMapper.MapBOToModel(this.DalBadgeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBadgeServerResponseModel>> Create(
			ApiBadgeServerRequestModel model)
		{
			CreateResponse<ApiBadgeServerResponseModel> response = ValidationResponseFactory<ApiBadgeServerResponseModel>.CreateResponse(await this.BadgeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolBadgeMapper.MapModelToBO(default(int), model);
				var record = await this.BadgeRepository.Create(this.DalBadgeMapper.MapBOToEF(bo));

				var businessObject = this.DalBadgeMapper.MapEFToBO(record);
				response.SetRecord(this.BolBadgeMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new BadgeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBadgeServerResponseModel>> Update(
			int id,
			ApiBadgeServerRequestModel model)
		{
			var validationResult = await this.BadgeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBadgeMapper.MapModelToBO(id, model);
				await this.BadgeRepository.Update(this.DalBadgeMapper.MapBOToEF(bo));

				var record = await this.BadgeRepository.Get(id);

				var businessObject = this.DalBadgeMapper.MapEFToBO(record);
				var apiModel = this.BolBadgeMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new BadgeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiBadgeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiBadgeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.BadgeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.BadgeRepository.Delete(id);

				await this.mediator.Publish(new BadgeDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dd0699c478b8010d28f3a0c76c474859</Hash>
</Codenesium>*/