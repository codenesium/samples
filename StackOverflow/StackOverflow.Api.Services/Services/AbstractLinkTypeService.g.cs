using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractLinkTypeService : AbstractService
	{
		private IMediator mediator;

		protected ILinkTypeRepository LinkTypeRepository { get; private set; }

		protected IApiLinkTypeServerRequestModelValidator LinkTypeModelValidator { get; private set; }

		protected IDALLinkTypeMapper DalLinkTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkTypeService(
			ILogger logger,
			IMediator mediator,
			ILinkTypeRepository linkTypeRepository,
			IApiLinkTypeServerRequestModelValidator linkTypeModelValidator,
			IDALLinkTypeMapper dalLinkTypeMapper)
			: base()
		{
			this.LinkTypeRepository = linkTypeRepository;
			this.LinkTypeModelValidator = linkTypeModelValidator;
			this.DalLinkTypeMapper = dalLinkTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLinkTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<LinkType> records = await this.LinkTypeRepository.All(limit, offset, query);

			return this.DalLinkTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiLinkTypeServerResponseModel> Get(int id)
		{
			LinkType record = await this.LinkTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLinkTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiLinkTypeServerResponseModel>> Create(
			ApiLinkTypeServerRequestModel model)
		{
			CreateResponse<ApiLinkTypeServerResponseModel> response = ValidationResponseFactory<ApiLinkTypeServerResponseModel>.CreateResponse(await this.LinkTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				LinkType record = this.DalLinkTypeMapper.MapModelToEntity(default(int), model);
				record = await this.LinkTypeRepository.Create(record);

				response.SetRecord(this.DalLinkTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new LinkTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkTypeServerResponseModel>> Update(
			int id,
			ApiLinkTypeServerRequestModel model)
		{
			var validationResult = await this.LinkTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				LinkType record = this.DalLinkTypeMapper.MapModelToEntity(id, model);
				await this.LinkTypeRepository.Update(record);

				record = await this.LinkTypeRepository.Get(id);

				ApiLinkTypeServerResponseModel apiModel = this.DalLinkTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new LinkTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiLinkTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiLinkTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LinkTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.LinkTypeRepository.Delete(id);

				await this.mediator.Publish(new LinkTypeDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>69e06029d949ceea6025cf3ace4112cd</Hash>
</Codenesium>*/