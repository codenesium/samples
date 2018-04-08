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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractLinkRepository(ILogger logger,
		                              ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFLink>().Add(record);
			this.context.SaveChanges();
			return record.Id;
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
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",id);
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
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFLink>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
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

		public virtual List<POCOLink> GetWhereDirect(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Links;
		}
		public virtual POCOLink GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response.Links.FirstOrDefault();
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
			efLink.Id = id;
			efLink.Name = name;
			efLink.DynamicParameters = dynamicParameters;
			efLink.StaticParameters = staticParameters;
			efLink.ChainId = chainId;
			efLink.AssignedMachineId = assignedMachineId;
			efLink.LinkStatusId = linkStatusId;
			efLink.Order = order;
			efLink.DateStarted = dateStarted;
			efLink.DateCompleted = dateCompleted;
			efLink.Response = response;
			efLink.ExternalId = externalId;
		}

		public static void MapEFToPOCO(EFLink efLink,Response response)
		{
			if(efLink == null)
			{
				return;
			}
			response.AddLink(new POCOLink()
			{
				Id = efLink.Id.ToInt(),
				Name = efLink.Name,
				DynamicParameters = efLink.DynamicParameters,
				StaticParameters = efLink.StaticParameters,
				Order = efLink.Order.ToInt(),
				DateStarted = efLink.DateStarted.ToNullableDateTime(),
				DateCompleted = efLink.DateCompleted.ToNullableDateTime(),
				Response = efLink.Response,
				ExternalId = efLink.ExternalId,

				ChainId = new ReferenceEntity<int>(efLink.ChainId,
				                                   "Chains"),
				AssignedMachineId = new ReferenceEntity<Nullable<int>>(efLink.AssignedMachineId,
				                                                       "Machines"),
				LinkStatusId = new ReferenceEntity<int>(efLink.LinkStatusId,
				                                        "LinkStatus"),
			});

			ChainRepository.MapEFToPOCO(efLink.Chain, response);

			MachineRepository.MapEFToPOCO(efLink.Machine, response);

			LinkStatusRepository.MapEFToPOCO(efLink.LinkStatus, response);
		}
	}
}

/*<Codenesium>
    <Hash>a02d685d03784ec58fd3b9011f65cdc0</Hash>
</Codenesium>*/