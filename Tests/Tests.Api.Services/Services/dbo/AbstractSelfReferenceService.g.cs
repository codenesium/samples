using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractSelfReferenceService : AbstractService
	{
		private ISelfReferenceRepository selfReferenceRepository;

		private IApiSelfReferenceRequestModelValidator selfReferenceModelValidator;

		private IBOLSelfReferenceMapper bolSelfReferenceMapper;

		private IDALSelfReferenceMapper dalSelfReferenceMapper;

		private ILogger logger;

		public AbstractSelfReferenceService(
			ILogger logger,
			ISelfReferenceRepository selfReferenceRepository,
			IApiSelfReferenceRequestModelValidator selfReferenceModelValidator,
			IBOLSelfReferenceMapper bolSelfReferenceMapper,
			IDALSelfReferenceMapper dalSelfReferenceMapper)
			: base()
		{
			this.selfReferenceRepository = selfReferenceRepository;
			this.selfReferenceModelValidator = selfReferenceModelValidator;
			this.bolSelfReferenceMapper = bolSelfReferenceMapper;
			this.dalSelfReferenceMapper = dalSelfReferenceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSelfReferenceResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.selfReferenceRepository.All(limit, offset);

			return this.bolSelfReferenceMapper.MapBOToModel(this.dalSelfReferenceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSelfReferenceResponseModel> Get(int id)
		{
			var record = await this.selfReferenceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolSelfReferenceMapper.MapBOToModel(this.dalSelfReferenceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSelfReferenceResponseModel>> Create(
			ApiSelfReferenceRequestModel model)
		{
			CreateResponse<ApiSelfReferenceResponseModel> response = new CreateResponse<ApiSelfReferenceResponseModel>(await this.selfReferenceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSelfReferenceMapper.MapModelToBO(default(int), model);
				var record = await this.selfReferenceRepository.Create(this.dalSelfReferenceMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSelfReferenceMapper.MapBOToModel(this.dalSelfReferenceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSelfReferenceResponseModel>> Update(
			int id,
			ApiSelfReferenceRequestModel model)
		{
			var validationResult = await this.selfReferenceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolSelfReferenceMapper.MapModelToBO(id, model);
				await this.selfReferenceRepository.Update(this.dalSelfReferenceMapper.MapBOToEF(bo));

				var record = await this.selfReferenceRepository.Get(id);

				return new UpdateResponse<ApiSelfReferenceResponseModel>(this.bolSelfReferenceMapper.MapBOToModel(this.dalSelfReferenceMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSelfReferenceResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.selfReferenceModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.selfReferenceRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiSelfReferenceResponseModel>> SelfReferences(int selfReferenceId, int limit = int.MaxValue, int offset = 0)
		{
			List<SelfReference> records = await this.selfReferenceRepository.SelfReferences(selfReferenceId, limit, offset);

			return this.bolSelfReferenceMapper.MapBOToModel(this.dalSelfReferenceMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b3ea120d36aea481da45171f7c0993be</Hash>
</Codenesium>*/