using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractFileTypeService : AbstractService
	{
		protected IFileTypeRepository FileTypeRepository { get; private set; }

		protected IApiFileTypeServerRequestModelValidator FileTypeModelValidator { get; private set; }

		protected IBOLFileTypeMapper BolFileTypeMapper { get; private set; }

		protected IDALFileTypeMapper DalFileTypeMapper { get; private set; }

		protected IBOLFileMapper BolFileMapper { get; private set; }

		protected IDALFileMapper DalFileMapper { get; private set; }

		private ILogger logger;

		public AbstractFileTypeService(
			ILogger logger,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeServerRequestModelValidator fileTypeModelValidator,
			IBOLFileTypeMapper bolFileTypeMapper,
			IDALFileTypeMapper dalFileTypeMapper,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base()
		{
			this.FileTypeRepository = fileTypeRepository;
			this.FileTypeModelValidator = fileTypeModelValidator;
			this.BolFileTypeMapper = bolFileTypeMapper;
			this.DalFileTypeMapper = dalFileTypeMapper;
			this.BolFileMapper = bolFileMapper;
			this.DalFileMapper = dalFileMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFileTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FileTypeRepository.All(limit, offset);

			return this.BolFileTypeMapper.MapBOToModel(this.DalFileTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFileTypeServerResponseModel> Get(int id)
		{
			var record = await this.FileTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFileTypeMapper.MapBOToModel(this.DalFileTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFileTypeServerResponseModel>> Create(
			ApiFileTypeServerRequestModel model)
		{
			CreateResponse<ApiFileTypeServerResponseModel> response = ValidationResponseFactory<ApiFileTypeServerResponseModel>.CreateResponse(await this.FileTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolFileTypeMapper.MapModelToBO(default(int), model);
				var record = await this.FileTypeRepository.Create(this.DalFileTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolFileTypeMapper.MapBOToModel(this.DalFileTypeMapper.MapEFToBO(record)));
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
				var bo = this.BolFileTypeMapper.MapModelToBO(id, model);
				await this.FileTypeRepository.Update(this.DalFileTypeMapper.MapBOToEF(bo));

				var record = await this.FileTypeRepository.Get(id);

				return ValidationResponseFactory<ApiFileTypeServerResponseModel>.UpdateResponse(this.BolFileTypeMapper.MapBOToModel(this.DalFileTypeMapper.MapEFToBO(record)));
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
			}

			return response;
		}

		public async virtual Task<List<ApiFileServerResponseModel>> FilesByFileTypeId(int fileTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<File> records = await this.FileTypeRepository.FilesByFileTypeId(fileTypeId, limit, offset);

			return this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>30819763cd0d52343e4846d299ab8405</Hash>
</Codenesium>*/