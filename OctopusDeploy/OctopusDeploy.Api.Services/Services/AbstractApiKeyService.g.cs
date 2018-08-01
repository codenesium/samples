using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractApiKeyService : AbstractService
	{
		private IApiKeyRepository apiKeyRepository;

		private IApiApiKeyRequestModelValidator apiKeyModelValidator;

		private IBOLApiKeyMapper bolApiKeyMapper;

		private IDALApiKeyMapper dalApiKeyMapper;

		private ILogger logger;

		public AbstractApiKeyService(
			ILogger logger,
			IApiKeyRepository apiKeyRepository,
			IApiApiKeyRequestModelValidator apiKeyModelValidator,
			IBOLApiKeyMapper bolApiKeyMapper,
			IDALApiKeyMapper dalApiKeyMapper)
			: base()
		{
			this.apiKeyRepository = apiKeyRepository;
			this.apiKeyModelValidator = apiKeyModelValidator;
			this.bolApiKeyMapper = bolApiKeyMapper;
			this.dalApiKeyMapper = dalApiKeyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiApiKeyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.apiKeyRepository.All(limit, offset);

			return this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiApiKeyResponseModel> Get(string id)
		{
			var record = await this.apiKeyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiApiKeyResponseModel>> Create(
			ApiApiKeyRequestModel model)
		{
			CreateResponse<ApiApiKeyResponseModel> response = new CreateResponse<ApiApiKeyResponseModel>(await this.apiKeyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolApiKeyMapper.MapModelToBO(default(string), model);
				var record = await this.apiKeyRepository.Create(this.dalApiKeyMapper.MapBOToEF(bo));

				response.SetRecord(this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiApiKeyResponseModel>> Update(
			string id,
			ApiApiKeyRequestModel model)
		{
			var validationResult = await this.apiKeyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolApiKeyMapper.MapModelToBO(id, model);
				await this.apiKeyRepository.Update(this.dalApiKeyMapper.MapBOToEF(bo));

				var record = await this.apiKeyRepository.Get(id);

				return new UpdateResponse<ApiApiKeyResponseModel>(this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiApiKeyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.apiKeyModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.apiKeyRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiApiKeyResponseModel> ByApiKeyHashed(string apiKeyHashed)
		{
			ApiKey record = await this.apiKeyRepository.ByApiKeyHashed(apiKeyHashed);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolApiKeyMapper.MapBOToModel(this.dalApiKeyMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>08c9853500cb61ef54a36c9741e72564</Hash>
</Codenesium>*/