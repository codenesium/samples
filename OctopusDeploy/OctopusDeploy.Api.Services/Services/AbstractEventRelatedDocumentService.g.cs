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
	public abstract class AbstractEventRelatedDocumentService : AbstractService
	{
		protected IEventRelatedDocumentRepository EventRelatedDocumentRepository { get; private set; }

		protected IApiEventRelatedDocumentRequestModelValidator EventRelatedDocumentModelValidator { get; private set; }

		protected IBOLEventRelatedDocumentMapper BolEventRelatedDocumentMapper { get; private set; }

		protected IDALEventRelatedDocumentMapper DalEventRelatedDocumentMapper { get; private set; }

		private ILogger logger;

		public AbstractEventRelatedDocumentService(
			ILogger logger,
			IEventRelatedDocumentRepository eventRelatedDocumentRepository,
			IApiEventRelatedDocumentRequestModelValidator eventRelatedDocumentModelValidator,
			IBOLEventRelatedDocumentMapper bolEventRelatedDocumentMapper,
			IDALEventRelatedDocumentMapper dalEventRelatedDocumentMapper)
			: base()
		{
			this.EventRelatedDocumentRepository = eventRelatedDocumentRepository;
			this.EventRelatedDocumentModelValidator = eventRelatedDocumentModelValidator;
			this.BolEventRelatedDocumentMapper = bolEventRelatedDocumentMapper;
			this.DalEventRelatedDocumentMapper = dalEventRelatedDocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEventRelatedDocumentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventRelatedDocumentRepository.All(limit, offset);

			return this.BolEventRelatedDocumentMapper.MapBOToModel(this.DalEventRelatedDocumentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventRelatedDocumentResponseModel> Get(int id)
		{
			var record = await this.EventRelatedDocumentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEventRelatedDocumentMapper.MapBOToModel(this.DalEventRelatedDocumentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventRelatedDocumentResponseModel>> Create(
			ApiEventRelatedDocumentRequestModel model)
		{
			CreateResponse<ApiEventRelatedDocumentResponseModel> response = new CreateResponse<ApiEventRelatedDocumentResponseModel>(await this.EventRelatedDocumentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEventRelatedDocumentMapper.MapModelToBO(default(int), model);
				var record = await this.EventRelatedDocumentRepository.Create(this.DalEventRelatedDocumentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEventRelatedDocumentMapper.MapBOToModel(this.DalEventRelatedDocumentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventRelatedDocumentResponseModel>> Update(
			int id,
			ApiEventRelatedDocumentRequestModel model)
		{
			var validationResult = await this.EventRelatedDocumentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventRelatedDocumentMapper.MapModelToBO(id, model);
				await this.EventRelatedDocumentRepository.Update(this.DalEventRelatedDocumentMapper.MapBOToEF(bo));

				var record = await this.EventRelatedDocumentRepository.Get(id);

				return new UpdateResponse<ApiEventRelatedDocumentResponseModel>(this.BolEventRelatedDocumentMapper.MapBOToModel(this.DalEventRelatedDocumentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEventRelatedDocumentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.EventRelatedDocumentModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.EventRelatedDocumentRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiEventRelatedDocumentResponseModel>> ByEventId(string eventId, int limit = 0, int offset = int.MaxValue)
		{
			List<EventRelatedDocument> records = await this.EventRelatedDocumentRepository.ByEventId(eventId, limit, offset);

			return this.BolEventRelatedDocumentMapper.MapBOToModel(this.DalEventRelatedDocumentMapper.MapEFToBO(records));
		}

		public async Task<List<ApiEventRelatedDocumentResponseModel>> ByEventIdRelatedDocumentId(string eventId, string relatedDocumentId, int limit = 0, int offset = int.MaxValue)
		{
			List<EventRelatedDocument> records = await this.EventRelatedDocumentRepository.ByEventIdRelatedDocumentId(eventId, relatedDocumentId, limit, offset);

			return this.BolEventRelatedDocumentMapper.MapBOToModel(this.DalEventRelatedDocumentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c5f77271844dbf56b66c6ed0f4b9359f</Hash>
</Codenesium>*/