using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractRowVersionCheckService : AbstractService
	{
		protected IRowVersionCheckRepository RowVersionCheckRepository { get; private set; }

		protected IApiRowVersionCheckServerRequestModelValidator RowVersionCheckModelValidator { get; private set; }

		protected IBOLRowVersionCheckMapper BolRowVersionCheckMapper { get; private set; }

		protected IDALRowVersionCheckMapper DalRowVersionCheckMapper { get; private set; }

		private ILogger logger;

		public AbstractRowVersionCheckService(
			ILogger logger,
			IRowVersionCheckRepository rowVersionCheckRepository,
			IApiRowVersionCheckServerRequestModelValidator rowVersionCheckModelValidator,
			IBOLRowVersionCheckMapper bolRowVersionCheckMapper,
			IDALRowVersionCheckMapper dalRowVersionCheckMapper)
			: base()
		{
			this.RowVersionCheckRepository = rowVersionCheckRepository;
			this.RowVersionCheckModelValidator = rowVersionCheckModelValidator;
			this.BolRowVersionCheckMapper = bolRowVersionCheckMapper;
			this.DalRowVersionCheckMapper = dalRowVersionCheckMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiRowVersionCheckServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.RowVersionCheckRepository.All(limit, offset);

			return this.BolRowVersionCheckMapper.MapBOToModel(this.DalRowVersionCheckMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiRowVersionCheckServerResponseModel> Get(int id)
		{
			var record = await this.RowVersionCheckRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolRowVersionCheckMapper.MapBOToModel(this.DalRowVersionCheckMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiRowVersionCheckServerResponseModel>> Create(
			ApiRowVersionCheckServerRequestModel model)
		{
			CreateResponse<ApiRowVersionCheckServerResponseModel> response = ValidationResponseFactory<ApiRowVersionCheckServerResponseModel>.CreateResponse(await this.RowVersionCheckModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolRowVersionCheckMapper.MapModelToBO(default(int), model);
				var record = await this.RowVersionCheckRepository.Create(this.DalRowVersionCheckMapper.MapBOToEF(bo));

				response.SetRecord(this.BolRowVersionCheckMapper.MapBOToModel(this.DalRowVersionCheckMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRowVersionCheckServerResponseModel>> Update(
			int id,
			ApiRowVersionCheckServerRequestModel model)
		{
			var validationResult = await this.RowVersionCheckModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolRowVersionCheckMapper.MapModelToBO(id, model);
				await this.RowVersionCheckRepository.Update(this.DalRowVersionCheckMapper.MapBOToEF(bo));

				var record = await this.RowVersionCheckRepository.Get(id);

				return ValidationResponseFactory<ApiRowVersionCheckServerResponseModel>.UpdateResponse(this.BolRowVersionCheckMapper.MapBOToModel(this.DalRowVersionCheckMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiRowVersionCheckServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.RowVersionCheckModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.RowVersionCheckRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3328db5b15f9750531c6821a95fb5d7c</Hash>
</Codenesium>*/