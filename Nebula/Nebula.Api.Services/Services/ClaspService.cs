using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ClaspService : AbstractService, IClaspService
	{
		private MediatR.IMediator mediator;

		protected IClaspRepository ClaspRepository { get; private set; }

		protected IApiClaspServerRequestModelValidator ClaspModelValidator { get; private set; }

		protected IDALClaspMapper DalClaspMapper { get; private set; }

		private ILogger logger;

		public ClaspService(
			ILogger<IClaspService> logger,
			MediatR.IMediator mediator,
			IClaspRepository claspRepository,
			IApiClaspServerRequestModelValidator claspModelValidator,
			IDALClaspMapper dalClaspMapper)
			: base()
		{
			this.ClaspRepository = claspRepository;
			this.ClaspModelValidator = claspModelValidator;
			this.DalClaspMapper = dalClaspMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiClaspServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Clasp> records = await this.ClaspRepository.All(limit, offset, query);

			return this.DalClaspMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiClaspServerResponseModel> Get(int id)
		{
			Clasp record = await this.ClaspRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalClaspMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiClaspServerResponseModel>> Create(
			ApiClaspServerRequestModel model)
		{
			CreateResponse<ApiClaspServerResponseModel> response = ValidationResponseFactory<ApiClaspServerResponseModel>.CreateResponse(await this.ClaspModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Clasp record = this.DalClaspMapper.MapModelToEntity(default(int), model);
				record = await this.ClaspRepository.Create(record);

				response.SetRecord(this.DalClaspMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ClaspCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiClaspServerResponseModel>> Update(
			int id,
			ApiClaspServerRequestModel model)
		{
			var validationResult = await this.ClaspModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Clasp record = this.DalClaspMapper.MapModelToEntity(id, model);
				await this.ClaspRepository.Update(record);

				record = await this.ClaspRepository.Get(id);

				ApiClaspServerResponseModel apiModel = this.DalClaspMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ClaspUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiClaspServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiClaspServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ClaspModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ClaspRepository.Delete(id);

				await this.mediator.Publish(new ClaspDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>206b47fcbfef4f94e4007f6a4c1d36bd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/