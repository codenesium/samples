using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPersonPhoneService : AbstractService
	{
		protected IPersonPhoneRepository PersonPhoneRepository { get; private set; }

		protected IApiPersonPhoneRequestModelValidator PersonPhoneModelValidator { get; private set; }

		protected IBOLPersonPhoneMapper BolPersonPhoneMapper { get; private set; }

		protected IDALPersonPhoneMapper DalPersonPhoneMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonPhoneService(
			ILogger logger,
			IPersonPhoneRepository personPhoneRepository,
			IApiPersonPhoneRequestModelValidator personPhoneModelValidator,
			IBOLPersonPhoneMapper bolPersonPhoneMapper,
			IDALPersonPhoneMapper dalPersonPhoneMapper)
			: base()
		{
			this.PersonPhoneRepository = personPhoneRepository;
			this.PersonPhoneModelValidator = personPhoneModelValidator;
			this.BolPersonPhoneMapper = bolPersonPhoneMapper;
			this.DalPersonPhoneMapper = dalPersonPhoneMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonPhoneRepository.All(limit, offset);

			return this.BolPersonPhoneMapper.MapBOToModel(this.DalPersonPhoneMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonPhoneResponseModel> Get(int businessEntityID)
		{
			var record = await this.PersonPhoneRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPersonPhoneMapper.MapBOToModel(this.DalPersonPhoneMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPersonPhoneResponseModel>> Create(
			ApiPersonPhoneRequestModel model)
		{
			CreateResponse<ApiPersonPhoneResponseModel> response = new CreateResponse<ApiPersonPhoneResponseModel>(await this.PersonPhoneModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPersonPhoneMapper.MapModelToBO(default(int), model);
				var record = await this.PersonPhoneRepository.Create(this.DalPersonPhoneMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPersonPhoneMapper.MapBOToModel(this.DalPersonPhoneMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonPhoneResponseModel>> Update(
			int businessEntityID,
			ApiPersonPhoneRequestModel model)
		{
			var validationResult = await this.PersonPhoneModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPersonPhoneMapper.MapModelToBO(businessEntityID, model);
				await this.PersonPhoneRepository.Update(this.DalPersonPhoneMapper.MapBOToEF(bo));

				var record = await this.PersonPhoneRepository.Get(businessEntityID);

				return new UpdateResponse<ApiPersonPhoneResponseModel>(this.BolPersonPhoneMapper.MapBOToModel(this.DalPersonPhoneMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPersonPhoneResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.PersonPhoneModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.PersonPhoneRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<List<ApiPersonPhoneResponseModel>> ByPhoneNumber(string phoneNumber, int limit = 0, int offset = int.MaxValue)
		{
			List<PersonPhone> records = await this.PersonPhoneRepository.ByPhoneNumber(phoneNumber, limit, offset);

			return this.BolPersonPhoneMapper.MapBOToModel(this.DalPersonPhoneMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>f5d0823c5b9cf19eb7d3a3e048235938</Hash>
</Codenesium>*/