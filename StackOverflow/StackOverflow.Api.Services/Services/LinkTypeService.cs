using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class LinkTypeService : AbstractService, ILinkTypeService
	{
		private MediatR.IMediator mediator;

		protected ILinkTypeRepository LinkTypeRepository { get; private set; }

		protected IApiLinkTypeServerRequestModelValidator LinkTypeModelValidator { get; private set; }

		protected IDALLinkTypeMapper DalLinkTypeMapper { get; private set; }

		protected IDALPostLinkMapper DalPostLinkMapper { get; private set; }

		private ILogger logger;

		public LinkTypeService(
			ILogger<ILinkTypeService> logger,
			MediatR.IMediator mediator,
			ILinkTypeRepository linkTypeRepository,
			IApiLinkTypeServerRequestModelValidator linkTypeModelValidator,
			IDALLinkTypeMapper dalLinkTypeMapper,
			IDALPostLinkMapper dalPostLinkMapper)
			: base()
		{
			this.LinkTypeRepository = linkTypeRepository;
			this.LinkTypeModelValidator = linkTypeModelValidator;
			this.DalLinkTypeMapper = dalLinkTypeMapper;
			this.DalPostLinkMapper = dalPostLinkMapper;
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

		public async virtual Task<List<ApiPostLinkServerResponseModel>> PostLinksByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostLink> records = await this.LinkTypeRepository.PostLinksByLinkTypeId(linkTypeId, limit, offset);

			return this.DalPostLinkMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>2c1952df7017fc7df31e1e85bfd13492</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/