using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class FileService : AbstractService, IFileService
	{
		private MediatR.IMediator mediator;

		protected IFileRepository FileRepository { get; private set; }

		protected IApiFileServerRequestModelValidator FileModelValidator { get; private set; }

		protected IDALFileMapper DalFileMapper { get; private set; }

		private ILogger logger;

		public FileService(
			ILogger<IFileService> logger,
			MediatR.IMediator mediator,
			IFileRepository fileRepository,
			IApiFileServerRequestModelValidator fileModelValidator,
			IDALFileMapper dalFileMapper)
			: base()
		{
			this.FileRepository = fileRepository;
			this.FileModelValidator = fileModelValidator;
			this.DalFileMapper = dalFileMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiFileServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<File> records = await this.FileRepository.All(limit, offset, query);

			return this.DalFileMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiFileServerResponseModel> Get(int id)
		{
			File record = await this.FileRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalFileMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiFileServerResponseModel>> Create(
			ApiFileServerRequestModel model)
		{
			CreateResponse<ApiFileServerResponseModel> response = ValidationResponseFactory<ApiFileServerResponseModel>.CreateResponse(await this.FileModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				File record = this.DalFileMapper.MapModelToEntity(default(int), model);
				record = await this.FileRepository.Create(record);

				response.SetRecord(this.DalFileMapper.MapEntityToModel(record));
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
				File record = this.DalFileMapper.MapModelToEntity(id, model);
				await this.FileRepository.Update(record);

				record = await this.FileRepository.Get(id);

				ApiFileServerResponseModel apiModel = this.DalFileMapper.MapEntityToModel(record);
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
    <Hash>156c46988c6a5136751e14c1def30c30</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/