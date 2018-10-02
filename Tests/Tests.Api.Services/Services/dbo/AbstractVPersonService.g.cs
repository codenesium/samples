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
	public abstract class AbstractVPersonService : AbstractService
	{
		protected IVPersonRepository VPersonRepository { get; private set; }

		protected IApiVPersonRequestModelValidator VPersonModelValidator { get; private set; }

		protected IBOLVPersonMapper BolVPersonMapper { get; private set; }

		protected IDALVPersonMapper DalVPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractVPersonService(
			ILogger logger,
			IVPersonRepository vPersonRepository,
			IApiVPersonRequestModelValidator vPersonModelValidator,
			IBOLVPersonMapper bolVPersonMapper,
			IDALVPersonMapper dalVPersonMapper)
			: base()
		{
			this.VPersonRepository = vPersonRepository;
			this.VPersonModelValidator = vPersonModelValidator;
			this.BolVPersonMapper = bolVPersonMapper;
			this.DalVPersonMapper = dalVPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VPersonRepository.All(limit, offset);

			return this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVPersonResponseModel> Get(int personId)
		{
			var record = await this.VPersonRepository.Get(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVPersonResponseModel>> Create(
			ApiVPersonRequestModel model)
		{
			CreateResponse<ApiVPersonResponseModel> response = new CreateResponse<ApiVPersonResponseModel>(await this.VPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVPersonMapper.MapModelToBO(default(int), model);
				var record = await this.VPersonRepository.Create(this.DalVPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVPersonResponseModel>> Update(
			int personId,
			ApiVPersonRequestModel model)
		{
			var validationResult = await this.VPersonModelValidator.ValidateUpdateAsync(personId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVPersonMapper.MapModelToBO(personId, model);
				await this.VPersonRepository.Update(this.DalVPersonMapper.MapBOToEF(bo));

				var record = await this.VPersonRepository.Get(personId);

				return new UpdateResponse<ApiVPersonResponseModel>(this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVPersonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int personId)
		{
			ActionResponse response = new ActionResponse(await this.VPersonModelValidator.ValidateDeleteAsync(personId));
			if (response.Success)
			{
				await this.VPersonRepository.Delete(personId);
			}

			return response;
		}

		public async Task<ApiVPersonResponseModel> ByPersonId(int personId)
		{
			VPerson record = await this.VPersonRepository.ByPersonId(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVPersonMapper.MapBOToModel(this.DalVPersonMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>561237ed53d98d659f9013789f5132d7</Hash>
</Codenesium>*/