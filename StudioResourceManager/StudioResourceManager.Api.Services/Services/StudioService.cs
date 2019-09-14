using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class StudioService : AbstractService, IStudioService
	{
		private MediatR.IMediator mediator;

		protected IStudioRepository StudioRepository { get; private set; }

		protected IApiStudioServerRequestModelValidator StudioModelValidator { get; private set; }

		protected IDALStudioMapper DalStudioMapper { get; private set; }

		private ILogger logger;

		public StudioService(
			ILogger<IStudioService> logger,
			MediatR.IMediator mediator,
			IStudioRepository studioRepository,
			IApiStudioServerRequestModelValidator studioModelValidator,
			IDALStudioMapper dalStudioMapper)
			: base()
		{
			this.StudioRepository = studioRepository;
			this.StudioModelValidator = studioModelValidator;
			this.DalStudioMapper = dalStudioMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiStudioServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Studio> records = await this.StudioRepository.All(limit, offset, query);

			return this.DalStudioMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiStudioServerResponseModel> Get(int id)
		{
			Studio record = await this.StudioRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalStudioMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiStudioServerResponseModel>> Create(
			ApiStudioServerRequestModel model)
		{
			CreateResponse<ApiStudioServerResponseModel> response = ValidationResponseFactory<ApiStudioServerResponseModel>.CreateResponse(await this.StudioModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Studio record = this.DalStudioMapper.MapModelToEntity(default(int), model);
				record = await this.StudioRepository.Create(record);

				response.SetRecord(this.DalStudioMapper.MapEntityToModel(record));
				await this.mediator.Publish(new StudioCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStudioServerResponseModel>> Update(
			int id,
			ApiStudioServerRequestModel model)
		{
			var validationResult = await this.StudioModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Studio record = this.DalStudioMapper.MapModelToEntity(id, model);
				await this.StudioRepository.Update(record);

				record = await this.StudioRepository.Get(id);

				ApiStudioServerResponseModel apiModel = this.DalStudioMapper.MapEntityToModel(record);
				await this.mediator.Publish(new StudioUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiStudioServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiStudioServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.StudioModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.StudioRepository.Delete(id);

				await this.mediator.Publish(new StudioDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>badc0614f75720e21393b393c41bf21e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/