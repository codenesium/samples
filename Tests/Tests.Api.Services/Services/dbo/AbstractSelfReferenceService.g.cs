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
		protected ISelfReferenceRepository SelfReferenceRepository { get; private set; }

		protected IApiSelfReferenceRequestModelValidator SelfReferenceModelValidator { get; private set; }

		protected IBOLSelfReferenceMapper BolSelfReferenceMapper { get; private set; }

		protected IDALSelfReferenceMapper DalSelfReferenceMapper { get; private set; }

		private ILogger logger;

		public AbstractSelfReferenceService(
			ILogger logger,
			ISelfReferenceRepository selfReferenceRepository,
			IApiSelfReferenceRequestModelValidator selfReferenceModelValidator,
			IBOLSelfReferenceMapper bolSelfReferenceMapper,
			IDALSelfReferenceMapper dalSelfReferenceMapper)
			: base()
		{
			this.SelfReferenceRepository = selfReferenceRepository;
			this.SelfReferenceModelValidator = selfReferenceModelValidator;
			this.BolSelfReferenceMapper = bolSelfReferenceMapper;
			this.DalSelfReferenceMapper = dalSelfReferenceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSelfReferenceResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SelfReferenceRepository.All(limit, offset);

			return this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSelfReferenceResponseModel> Get(int id)
		{
			var record = await this.SelfReferenceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSelfReferenceResponseModel>> Create(
			ApiSelfReferenceRequestModel model)
		{
			CreateResponse<ApiSelfReferenceResponseModel> response = new CreateResponse<ApiSelfReferenceResponseModel>(await this.SelfReferenceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSelfReferenceMapper.MapModelToBO(default(int), model);
				var record = await this.SelfReferenceRepository.Create(this.DalSelfReferenceMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSelfReferenceResponseModel>> Update(
			int id,
			ApiSelfReferenceRequestModel model)
		{
			var validationResult = await this.SelfReferenceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSelfReferenceMapper.MapModelToBO(id, model);
				await this.SelfReferenceRepository.Update(this.DalSelfReferenceMapper.MapBOToEF(bo));

				var record = await this.SelfReferenceRepository.Get(id);

				return new UpdateResponse<ApiSelfReferenceResponseModel>(this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSelfReferenceResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SelfReferenceModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SelfReferenceRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiSelfReferenceResponseModel>> SelfReferences(int selfReferenceId, int limit = int.MaxValue, int offset = 0)
		{
			List<SelfReference> records = await this.SelfReferenceRepository.SelfReferences(selfReferenceId, limit, offset);

			return this.BolSelfReferenceMapper.MapBOToModel(this.DalSelfReferenceMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>61554dd98c8c15feba5e9c5fe9b2de42</Hash>
</Codenesium>*/