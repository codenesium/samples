using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDestinationService: AbstractService
	{
		private IDestinationRepository destinationRepository;
		private IApiDestinationRequestModelValidator destinationModelValidator;
		private IBOLDestinationMapper bolDestinationMapper;
		private IDALDestinationMapper dalDestinationMapper;
		private ILogger logger;

		public AbstractDestinationService(
			ILogger logger,
			IDestinationRepository destinationRepository,
			IApiDestinationRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper boldestinationMapper,
			IDALDestinationMapper daldestinationMapper)
			: base()

		{
			this.destinationRepository = destinationRepository;
			this.destinationModelValidator = destinationModelValidator;
			this.bolDestinationMapper = boldestinationMapper;
			this.dalDestinationMapper = daldestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.destinationRepository.All(skip, take, orderClause);

			return this.bolDestinationMapper.MapBOToModel(this.dalDestinationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDestinationResponseModel> Get(int id)
		{
			var record = await destinationRepository.Get(id);

			return this.bolDestinationMapper.MapBOToModel(this.dalDestinationMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiDestinationResponseModel>> Create(
			ApiDestinationRequestModel model)
		{
			CreateResponse<ApiDestinationResponseModel> response = new CreateResponse<ApiDestinationResponseModel>(await this.destinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolDestinationMapper.MapModelToBO(default (int), model);
				var record = await this.destinationRepository.Create(this.dalDestinationMapper.MapBOToEF(bo));

				response.SetRecord(this.bolDestinationMapper.MapBOToModel(this.dalDestinationMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiDestinationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.destinationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolDestinationMapper.MapModelToBO(id, model);
				await this.destinationRepository.Update(this.dalDestinationMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.destinationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.destinationRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a7baf7249e7423ea8206200dcddd5ed6</Hash>
</Codenesium>*/