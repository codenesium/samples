using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractLinkTypesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ILinkTypesRepository LinkTypesRepository { get; private set; }

		protected IApiLinkTypesServerRequestModelValidator LinkTypesModelValidator { get; private set; }

		protected IDALLinkTypesMapper DalLinkTypesMapper { get; private set; }

		protected IDALPostLinksMapper DalPostLinksMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkTypesService(
			ILogger logger,
			MediatR.IMediator mediator,
			ILinkTypesRepository linkTypesRepository,
			IApiLinkTypesServerRequestModelValidator linkTypesModelValidator,
			IDALLinkTypesMapper dalLinkTypesMapper,
			IDALPostLinksMapper dalPostLinksMapper)
			: base()
		{
			this.LinkTypesRepository = linkTypesRepository;
			this.LinkTypesModelValidator = linkTypesModelValidator;
			this.DalLinkTypesMapper = dalLinkTypesMapper;
			this.DalPostLinksMapper = dalPostLinksMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLinkTypesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<LinkTypes> records = await this.LinkTypesRepository.All(limit, offset, query);

			return this.DalLinkTypesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiLinkTypesServerResponseModel> Get(int id)
		{
			LinkTypes record = await this.LinkTypesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLinkTypesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiLinkTypesServerResponseModel>> Create(
			ApiLinkTypesServerRequestModel model)
		{
			CreateResponse<ApiLinkTypesServerResponseModel> response = ValidationResponseFactory<ApiLinkTypesServerResponseModel>.CreateResponse(await this.LinkTypesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				LinkTypes record = this.DalLinkTypesMapper.MapModelToEntity(default(int), model);
				record = await this.LinkTypesRepository.Create(record);

				response.SetRecord(this.DalLinkTypesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new LinkTypesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkTypesServerResponseModel>> Update(
			int id,
			ApiLinkTypesServerRequestModel model)
		{
			var validationResult = await this.LinkTypesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				LinkTypes record = this.DalLinkTypesMapper.MapModelToEntity(id, model);
				await this.LinkTypesRepository.Update(record);

				record = await this.LinkTypesRepository.Get(id);

				ApiLinkTypesServerResponseModel apiModel = this.DalLinkTypesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new LinkTypesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiLinkTypesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiLinkTypesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LinkTypesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.LinkTypesRepository.Delete(id);

				await this.mediator.Publish(new LinkTypesDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostLinksServerResponseModel>> PostLinksByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostLinks> records = await this.LinkTypesRepository.PostLinksByLinkTypeId(linkTypeId, limit, offset);

			return this.DalPostLinksMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>17926253b712f583b31e8bae6c531f9c</Hash>
</Codenesium>*/