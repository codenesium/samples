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
	public abstract class AbstractLinkTypesService : AbstractService
	{
		protected ILinkTypesRepository LinkTypesRepository { get; private set; }

		protected IApiLinkTypesRequestModelValidator LinkTypesModelValidator { get; private set; }

		protected IBOLLinkTypesMapper BolLinkTypesMapper { get; private set; }

		protected IDALLinkTypesMapper DalLinkTypesMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkTypesService(
			ILogger logger,
			ILinkTypesRepository linkTypesRepository,
			IApiLinkTypesRequestModelValidator linkTypesModelValidator,
			IBOLLinkTypesMapper bolLinkTypesMapper,
			IDALLinkTypesMapper dalLinkTypesMapper)
			: base()
		{
			this.LinkTypesRepository = linkTypesRepository;
			this.LinkTypesModelValidator = linkTypesModelValidator;
			this.BolLinkTypesMapper = bolLinkTypesMapper;
			this.DalLinkTypesMapper = dalLinkTypesMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkTypesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkTypesRepository.All(limit, offset);

			return this.BolLinkTypesMapper.MapBOToModel(this.DalLinkTypesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkTypesResponseModel> Get(int id)
		{
			var record = await this.LinkTypesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkTypesMapper.MapBOToModel(this.DalLinkTypesMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkTypesResponseModel>> Create(
			ApiLinkTypesRequestModel model)
		{
			CreateResponse<ApiLinkTypesResponseModel> response = new CreateResponse<ApiLinkTypesResponseModel>(await this.LinkTypesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLinkTypesMapper.MapModelToBO(default(int), model);
				var record = await this.LinkTypesRepository.Create(this.DalLinkTypesMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLinkTypesMapper.MapBOToModel(this.DalLinkTypesMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkTypesResponseModel>> Update(
			int id,
			ApiLinkTypesRequestModel model)
		{
			var validationResult = await this.LinkTypesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLinkTypesMapper.MapModelToBO(id, model);
				await this.LinkTypesRepository.Update(this.DalLinkTypesMapper.MapBOToEF(bo));

				var record = await this.LinkTypesRepository.Get(id);

				return new UpdateResponse<ApiLinkTypesResponseModel>(this.BolLinkTypesMapper.MapBOToModel(this.DalLinkTypesMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLinkTypesResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LinkTypesModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LinkTypesRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>73840d7fc07c45b9b019d7f510d0bdb2</Hash>
</Codenesium>*/