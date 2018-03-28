using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractLinkRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractLinkRepository(ILogger logger,
		                              ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          string dynamicParameters,
		                          string staticParameters,
		                          int chainId,
		                          Nullable<int> assignedMachineId,
		                          int linkStatusId,
		                          int order,
		                          Nullable<DateTime> dateStarted,
		                          Nullable<DateTime> dateCompleted,
		                          string response,
		                          Guid externalId)
		{
			var record = new EFLink ();

			MapPOCOToEF(0, name,
			            dynamicParameters,
			            staticParameters,
			            chainId,
			            assignedMachineId,
			            linkStatusId,
			            order,
			            dateStarted,
			            dateCompleted,
			            response,
			            externalId, record);

			this._context.Set<EFLink>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(int id, string name,
		                           string dynamicParameters,
		                           string staticParameters,
		                           int chainId,
		                           Nullable<int> assignedMachineId,
		                           int linkStatusId,
		                           int order,
		                           Nullable<DateTime> dateStarted,
		                           Nullable<DateTime> dateCompleted,
		                           string response,
		                           Guid externalId)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            dynamicParameters,
				            staticParameters,
				            chainId,
				            assignedMachineId,
				            linkStatusId,
				            order,
				            dateStarted,
				            dateCompleted,
				            response,
				            externalId, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFLink>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<EFLink> SearchLinqEF(Expression<Func<EFLink, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFLink> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFLink, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFLink, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFLink> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFLink> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name,
		                               string dynamicParameters,
		                               string staticParameters,
		                               int chainId,
		                               Nullable<int> assignedMachineId,
		                               int linkStatusId,
		                               int order,
		                               Nullable<DateTime> dateStarted,
		                               Nullable<DateTime> dateCompleted,
		                               string response,
		                               Guid externalId, EFLink   efLink)
		{
			efLink.id = id;
			efLink.name = name;
			efLink.dynamicParameters = dynamicParameters;
			efLink.staticParameters = staticParameters;
			efLink.chainId = chainId;
			efLink.assignedMachineId = assignedMachineId;
			efLink.linkStatusId = linkStatusId;
			efLink.order = order;
			efLink.dateStarted = dateStarted;
			efLink.dateCompleted = dateCompleted;
			efLink.response = response;
			efLink.externalId = externalId;
		}

		public static void MapEFToPOCO(EFLink efLink,Response response)
		{
			if(efLink == null)
			{
				return;
			}
			response.AddLink(new POCOLink()
			{
				Id = efLink.id.ToInt(),
				Name = efLink.name,
				DynamicParameters = efLink.dynamicParameters,
				StaticParameters = efLink.staticParameters,
				Order = efLink.order.ToInt(),
				DateStarted = efLink.dateStarted.ToNullableDateTime(),
				DateCompleted = efLink.dateCompleted.ToNullableDateTime(),
				Response = efLink.response,
				ExternalId = efLink.externalId,

				ChainId = new ReferenceEntity<int>(efLink.chainId,
				                                   "Chains"),
				AssignedMachineId = new ReferenceEntity<Nullable<int>>(efLink.assignedMachineId,
				                                                       "Machines"),
				LinkStatusId = new ReferenceEntity<int>(efLink.linkStatusId,
				                                        "LinkStatus"),
			});

			ChainRepository.MapEFToPOCO(efLink.ChainRef, response);

			MachineRepository.MapEFToPOCO(efLink.MachineRef, response);

			LinkStatusRepository.MapEFToPOCO(efLink.LinkStatusRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>62cba74fc18da749341958d28f3d8198</Hash>
</Codenesium>*/