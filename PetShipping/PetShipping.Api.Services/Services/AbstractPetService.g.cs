using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPetService : AbstractService
	{
		protected IPetRepository PetRepository { get; private set; }

		protected IApiPetRequestModelValidator PetModelValidator { get; private set; }

		protected IBOLPetMapper BolPetMapper { get; private set; }

		protected IDALPetMapper DalPetMapper { get; private set; }

		protected IBOLSaleMapper BolSaleMapper { get; private set; }

		protected IDALSaleMapper DalSaleMapper { get; private set; }

		private ILogger logger;

		public AbstractPetService(
			ILogger logger,
			IPetRepository petRepository,
			IApiPetRequestModelValidator petModelValidator,
			IBOLPetMapper bolPetMapper,
			IDALPetMapper dalPetMapper,
			IBOLSaleMapper bolSaleMapper,
			IDALSaleMapper dalSaleMapper)
			: base()
		{
			this.PetRepository = petRepository;
			this.PetModelValidator = petModelValidator;
			this.BolPetMapper = bolPetMapper;
			this.DalPetMapper = dalPetMapper;
			this.BolSaleMapper = bolSaleMapper;
			this.DalSaleMapper = dalSaleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPetResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PetRepository.All(limit, offset);

			return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPetResponseModel> Get(int id)
		{
			var record = await this.PetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPetResponseModel>> Create(
			ApiPetRequestModel model)
		{
			CreateResponse<ApiPetResponseModel> response = new CreateResponse<ApiPetResponseModel>(await this.PetModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPetMapper.MapModelToBO(default(int), model);
				var record = await this.PetRepository.Create(this.DalPetMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPetResponseModel>> Update(
			int id,
			ApiPetRequestModel model)
		{
			var validationResult = await this.PetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPetMapper.MapModelToBO(id, model);
				await this.PetRepository.Update(this.DalPetMapper.MapBOToEF(bo));

				var record = await this.PetRepository.Get(id);

				return new UpdateResponse<ApiPetResponseModel>(this.BolPetMapper.MapBOToModel(this.DalPetMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPetResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PetModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PetRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiSaleResponseModel>> Sales(int petId, int limit = int.MaxValue, int offset = 0)
		{
			List<Sale> records = await this.PetRepository.Sales(petId, limit, offset);

			return this.BolSaleMapper.MapBOToModel(this.DalSaleMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7860d6d6a09e45ac1acd13aef4c09f4c</Hash>
</Codenesium>*/