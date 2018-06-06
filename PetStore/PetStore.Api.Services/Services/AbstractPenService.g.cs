using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractPenService: AbstractService
	{
		private IPenRepository penRepository;
		private IApiPenRequestModelValidator penModelValidator;
		private IBOLPenMapper bolPenMapper;
		private IDALPenMapper dalPenMapper;
		private ILogger logger;

		public AbstractPenService(
			ILogger logger,
			IPenRepository penRepository,
			IApiPenRequestModelValidator penModelValidator,
			IBOLPenMapper bolpenMapper,
			IDALPenMapper dalpenMapper)
			: base()

		{
			this.penRepository = penRepository;
			this.penModelValidator = penModelValidator;
			this.bolPenMapper = bolpenMapper;
			this.dalPenMapper = dalpenMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPenResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.penRepository.All(skip, take, orderClause);

			return this.bolPenMapper.MapBOToModel(this.dalPenMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPenResponseModel> Get(int id)
		{
			var record = await penRepository.Get(id);

			return this.bolPenMapper.MapBOToModel(this.dalPenMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPenResponseModel>> Create(
			ApiPenRequestModel model)
		{
			CreateResponse<ApiPenResponseModel> response = new CreateResponse<ApiPenResponseModel>(await this.penModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPenMapper.MapModelToBO(default (int), model);
				var record = await this.penRepository.Create(this.dalPenMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPenMapper.MapBOToModel(this.dalPenMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPenRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolPenMapper.MapModelToBO(id, model);
				await this.penRepository.Update(this.dalPenMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.penRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>48ef568a8984b3ede6229d371dc61987</Hash>
</Codenesium>*/