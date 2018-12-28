using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractFileService : AbstractService
	{
		private IMediator mediator;

		protected IFileRepository FileRepository { get; private set; }

		protected IApiFileServerRequestModelValidator FileModelValidator { get; private set; }

		protected IBOLFileMapper BolFileMapper { get; private set; }

		protected IDALFileMapper DalFileMapper { get; private set; }

		private ILogger logger;

		public AbstractFileService(
			ILogger logger,
			IMediator mediator,
			IFileRepository fileRepository,
			IApiFileServerRequestModelValidator fileModelValidator,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base()
		{
			this.FileRepository = fileRepository;
			this.FileModelValidator = fileModelValidator;
			this.BolFileMapper = bolFileMapper;
			this.DalFileMapper = dalFileMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiFileServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FileRepository.All(limit, offset);

			return this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFileServerResponseModel> Get(int id)
		{
			var record = await this.FileRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFileServerResponseModel>> Create(
			ApiFileServerRequestModel model)
		{
			CreateResponse<ApiFileServerResponseModel> response = ValidationResponseFactory<ApiFileServerResponseModel>.CreateResponse(await this.FileModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolFileMapper.MapModelToBO(default(int), model);
				var record = await this.FileRepository.Create(this.DalFileMapper.MapBOToEF(bo));

				var businessObject = this.DalFileMapper.MapEFToBO(record);
				response.SetRecord(this.BolFileMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new FileCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFileServerResponseModel>> Update(
			int id,
			ApiFileServerRequestModel model)
		{
			var validationResult = await this.FileModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolFileMapper.MapModelToBO(id, model);
				await this.FileRepository.Update(this.DalFileMapper.MapBOToEF(bo));

				var record = await this.FileRepository.Get(id);

				var businessObject = this.DalFileMapper.MapEFToBO(record);
				var apiModel = this.BolFileMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new FileUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiFileServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiFileServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.FileModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.FileRepository.Delete(id);

				await this.mediator.Publish(new FileDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ecc0edfb78f61b08898039c18799c698</Hash>
</Codenesium>*/