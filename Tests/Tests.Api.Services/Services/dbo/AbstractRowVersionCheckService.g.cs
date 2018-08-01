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
	public abstract class AbstractRowVersionCheckService : AbstractService
	{
		private IRowVersionCheckRepository rowVersionCheckRepository;

		private IApiRowVersionCheckRequestModelValidator rowVersionCheckModelValidator;

		private IBOLRowVersionCheckMapper bolRowVersionCheckMapper;

		private IDALRowVersionCheckMapper dalRowVersionCheckMapper;

		private ILogger logger;

		public AbstractRowVersionCheckService(
			ILogger logger,
			IRowVersionCheckRepository rowVersionCheckRepository,
			IApiRowVersionCheckRequestModelValidator rowVersionCheckModelValidator,
			IBOLRowVersionCheckMapper bolRowVersionCheckMapper,
			IDALRowVersionCheckMapper dalRowVersionCheckMapper)
			: base()
		{
			this.rowVersionCheckRepository = rowVersionCheckRepository;
			this.rowVersionCheckModelValidator = rowVersionCheckModelValidator;
			this.bolRowVersionCheckMapper = bolRowVersionCheckMapper;
			this.dalRowVersionCheckMapper = dalRowVersionCheckMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiRowVersionCheckResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.rowVersionCheckRepository.All(limit, offset);

			return this.bolRowVersionCheckMapper.MapBOToModel(this.dalRowVersionCheckMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiRowVersionCheckResponseModel> Get(int id)
		{
			var record = await this.rowVersionCheckRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolRowVersionCheckMapper.MapBOToModel(this.dalRowVersionCheckMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiRowVersionCheckResponseModel>> Create(
			ApiRowVersionCheckRequestModel model)
		{
			CreateResponse<ApiRowVersionCheckResponseModel> response = new CreateResponse<ApiRowVersionCheckResponseModel>(await this.rowVersionCheckModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolRowVersionCheckMapper.MapModelToBO(default(int), model);
				var record = await this.rowVersionCheckRepository.Create(this.dalRowVersionCheckMapper.MapBOToEF(bo));

				response.SetRecord(this.bolRowVersionCheckMapper.MapBOToModel(this.dalRowVersionCheckMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRowVersionCheckResponseModel>> Update(
			int id,
			ApiRowVersionCheckRequestModel model)
		{
			var validationResult = await this.rowVersionCheckModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolRowVersionCheckMapper.MapModelToBO(id, model);
				await this.rowVersionCheckRepository.Update(this.dalRowVersionCheckMapper.MapBOToEF(bo));

				var record = await this.rowVersionCheckRepository.Get(id);

				return new UpdateResponse<ApiRowVersionCheckResponseModel>(this.bolRowVersionCheckMapper.MapBOToModel(this.dalRowVersionCheckMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiRowVersionCheckResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.rowVersionCheckModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.rowVersionCheckRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1f9abb9679f954b81f567c259af21a55</Hash>
</Codenesium>*/