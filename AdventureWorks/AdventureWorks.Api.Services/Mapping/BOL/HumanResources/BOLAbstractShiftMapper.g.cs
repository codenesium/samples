using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractShiftMapper
        {
                public virtual BOShift MapModelToBO(
                        int shiftID,
                        ApiShiftRequestModel model
                        )
                {
                        BOShift boShift = new BOShift();

                        boShift.SetProperties(
                                shiftID,
                                model.EndTime,
                                model.ModifiedDate,
                                model.Name,
                                model.StartTime);
                        return boShift;
                }

                public virtual ApiShiftResponseModel MapBOToModel(
                        BOShift boShift)
                {
                        var model = new ApiShiftResponseModel();

                        model.SetProperties(boShift.EndTime, boShift.ModifiedDate, boShift.Name, boShift.ShiftID, boShift.StartTime);

                        return model;
                }

                public virtual List<ApiShiftResponseModel> MapBOToModel(
                        List<BOShift> items)
                {
                        List<ApiShiftResponseModel> response = new List<ApiShiftResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>804e9f4b628df70872085d8aa8fbfba5</Hash>
</Codenesium>*/