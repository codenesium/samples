using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractSpaceXSpaceFeatureMapper
        {
                public virtual SpaceXSpaceFeature MapBOToEF(
                        BOSpaceXSpaceFeature bo)
                {
                        SpaceXSpaceFeature efSpaceXSpaceFeature = new SpaceXSpaceFeature();
                        efSpaceXSpaceFeature.SetProperties(
                                bo.Id,
                                bo.SpaceFeatureId,
                                bo.SpaceId);
                        return efSpaceXSpaceFeature;
                }

                public virtual BOSpaceXSpaceFeature MapEFToBO(
                        SpaceXSpaceFeature ef)
                {
                        var bo = new BOSpaceXSpaceFeature();

                        bo.SetProperties(
                                ef.Id,
                                ef.SpaceFeatureId,
                                ef.SpaceId);
                        return bo;
                }

                public virtual List<BOSpaceXSpaceFeature> MapEFToBO(
                        List<SpaceXSpaceFeature> records)
                {
                        List<BOSpaceXSpaceFeature> response = new List<BOSpaceXSpaceFeature>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>64fe7185fba2a4f3ce9f4ed681e809bd</Hash>
</Codenesium>*/