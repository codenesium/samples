using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class FileTypeService : AbstractService, IFileTypeService
	{
		private MediatR.IMediator mediator;

		protected IFileTypeRepository FileTypeRepository { get; private set; }

		protected IApiFileTypeServerRequestModelValidator FileTypeModelValidator { get; private set; }

		protected IDALFileTypeMapper DalFileTypeMapper { get; private set; }

		protected IDALFileMapper DalFileMapper { get; private set; }

		private ILogger logger;

		public FileTypeService(
			ILogger<IFileTypeService> logger,
			MediatR.IMediator mediator,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeServerRequestModelValidator fileTypeModelValidator,
			IDALFileTypeMapper dalFileTypeMapper,
			IDALFileMapper dalFileMapper)
			: base()
		{
			this.FileTypeRepository = fileTypeRepository;
			this.FileTypeModelValidator = fileTypeModelValidator;
			this.DalFileTypeMapper = dalFileTypeMapper;
			this.DalFileMapper = dalFileMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiFileTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<FileType> records = await this.FileTypeRepository.All(limit, offset, query);

			return this.DalFileTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiFileTypeServerResponseModel> Get(int id)
		{
			FileType record = await this.FileTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalFileTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiFileTypeServerResponseModel>> Create(
			ApiFileTypeServerRequestModel model)
		{
			CreateResponse<ApiFileTypeServerResponseModel> response = ValidationResponseFactory<ApiFileTypeServerResponseModel>.CreateResponse(await this.FileTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				FileType record = this.DalFileTypeMapper.MapModelToEntity(default(int), model);
				record = await this.FileTypeRepository.Create(record);

				response.SetRecord(this.DalFileTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new FileTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFileTypeServerResponseModel>> Update(
			int id,
			ApiFileTypeServerRequestModel model)
		{
			var validationResult = await this.FileTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				FileType record = this.DalFileTypeMapper.MapModelToEntity(id, model);
				await this.FileTypeRepository.Update(record);

				record = await this.FileTypeRepository.Get(id);

				ApiFileTypeServerResponseModel apiModel = this.DalFileTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new FileTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiFileTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiFileTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.FileTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.FileTypeRepository.Delete(id);

				await this.mediator.Publish(new FileTypeDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiFileServerResponseModel>> FilesByFileTypeId(int fileTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<File> records = await this.FileTypeRepository.FilesByFileTypeId(fileTypeId, limit, offset);

			return this.DalFileMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>123d216d46abf3122721d562b662d830</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/