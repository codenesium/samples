using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostTypesService : AbstractService
	{
		protected IPostTypesRepository PostTypesRepository { get; private set; }

		protected IApiPostTypesRequestModelValidator PostTypesModelValidator { get; private set; }

		protected IBOLPostTypesMapper BolPostTypesMapper { get; private set; }

		protected IDALPostTypesMapper DalPostTypesMapper { get; private set; }

		private ILogger logger;

		public AbstractPostTypesService(
			ILogger logger,
			IPostTypesRepository postTypesRepository,
			IApiPostTypesRequestModelValidator postTypesModelValidator,
			IBOLPostTypesMapper bolPostTypesMapper,
			IDALPostTypesMapper dalPostTypesMapper)
			: base()
		{
			this.PostTypesRepository = postTypesRepository;
			this.PostTypesModelValidator = postTypesModelValidator;
			this.BolPostTypesMapper = bolPostTypesMapper;
			this.DalPostTypesMapper = dalPostTypesMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostTypesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostTypesRepository.All(limit, offset);

			return this.BolPostTypesMapper.MapBOToModel(this.DalPostTypesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostTypesResponseModel> Get(int id)
		{
			var record = await this.PostTypesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostTypesMapper.MapBOToModel(this.DalPostTypesMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostTypesResponseModel>> Create(
			ApiPostTypesRequestModel model)
		{
			CreateResponse<ApiPostTypesResponseModel> response = new CreateResponse<ApiPostTypesResponseModel>(await this.PostTypesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostTypesMapper.MapModelToBO(default(int), model);
				var record = await this.PostTypesRepository.Create(this.DalPostTypesMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostTypesMapper.MapBOToModel(this.DalPostTypesMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostTypesResponseModel>> Update(
			int id,
			ApiPostTypesRequestModel model)
		{
			var validationResult = await this.PostTypesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostTypesMapper.MapModelToBO(id, model);
				await this.PostTypesRepository.Update(this.DalPostTypesMapper.MapBOToEF(bo));

				var record = await this.PostTypesRepository.Get(id);

				return new UpdateResponse<ApiPostTypesResponseModel>(this.BolPostTypesMapper.MapBOToModel(this.DalPostTypesMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostTypesResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostTypesModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostTypesRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5d0b8aa1407c7ebc34eaeb93d2db6cbb</Hash>
</Codenesium>*/