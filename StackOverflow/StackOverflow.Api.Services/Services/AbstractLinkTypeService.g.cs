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

		protected IBOLLinkTypeMapper BolLinkTypeMapper { get; private set; }

		protected IDALLinkTypeMapper DalLinkTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkTypeService(
			ILogger logger,
			IMediator mediator,
			ILinkTypeRepository linkTypeRepository,
			IApiLinkTypeServerRequestModelValidator linkTypeModelValidator,
			IBOLLinkTypeMapper bolLinkTypeMapper,
			IDALLinkTypeMapper dalLinkTypeMapper)
			: base()
		{
			this.LinkTypeRepository = linkTypeRepository;
			this.LinkTypeModelValidator = linkTypeModelValidator;
			this.BolLinkTypeMapper = bolLinkTypeMapper;
			this.DalLinkTypeMapper = dalLinkTypeMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLinkTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkTypeRepository.All(limit, offset);

			return this.BolLinkTypeMapper.MapBOToModel(this.DalLinkTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkTypeServerResponseModel> Get(int id)
		{
			var record = await this.LinkTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkTypeMapper.MapBOToModel(this.DalLinkTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkTypeServerResponseModel>> Create(
			ApiLinkTypeServerRequestModel model)
		{
			CreateResponse<ApiLinkTypeServerResponseModel> response = ValidationResponseFactory<ApiLinkTypeServerResponseModel>.CreateResponse(await this.LinkTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolLinkTypeMapper.MapModelToBO(default(int), model);
				var record = await this.LinkTypeRepository.Create(this.DalLinkTypeMapper.MapBOToEF(bo));

				var businessObject = this.DalLinkTypeMapper.MapEFToBO(record);
				response.SetRecord(this.BolLinkTypeMapper.MapBOToModel(businessObject));
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
				var bo = this.BolLinkTypeMapper.MapModelToBO(id, model);
				await this.LinkTypeRepository.Update(this.DalLinkTypeMapper.MapBOToEF(bo));

				var record = await this.LinkTypeRepository.Get(id);

				var businessObject = this.DalLinkTypeMapper.MapEFToBO(record);
				var apiModel = this.BolLinkTypeMapper.MapBOToModel(businessObject);
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
    <Hash>3ca67e4dbe08830e5ab2e4a29865d17b</Hash>
</Codenesium>*/