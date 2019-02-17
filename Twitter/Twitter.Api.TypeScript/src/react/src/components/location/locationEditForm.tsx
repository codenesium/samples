import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import LocationViewModel from './locationViewModel';
import LocationMapper from './locationMapper';

interface Props {
    model?:LocationViewModel
}

  const LocationEditDisplay = (props: FormikProps<LocationViewModel>) => {

   let status = props.status as UpdateResponse<Api.LocationClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof LocationViewModel]  && props.errors[name as keyof LocationViewModel]) {
            response += props.errors[name as keyof LocationViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

    
   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("gpsLat") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Gps_lat</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="gpsLat" className={errorExistForField("gpsLat") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("gpsLat") && <small className="text-danger">{errorsForField("gpsLat")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("gpsLong") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Gps_long</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="gpsLong" className={errorExistForField("gpsLong") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("gpsLong") && <small className="text-danger">{errorsForField("gpsLong")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("locationName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Location_name</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="locationName" className={errorExistForField("locationName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("locationName") && <small className="text-danger">{errorsForField("locationName")}</small>}
                        </div>
                    </div>
			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>
  );
}


const LocationEdit = withFormik<Props, LocationViewModel>({
    mapPropsToValues: props => {
        let response = new LocationViewModel();
		response.setProperties(props.model!.gpsLat,props.model!.gpsLong,props.model!.locationId,props.model!.locationName);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<LocationViewModel> = { };

	  if(values.gpsLat == 0) {
                errors.gpsLat = "Required"
                    }if(values.gpsLong == 0) {
                errors.gpsLong = "Required"
                    }if(values.locationId == 0) {
                errors.locationId = "Required"
                    }if(values.locationName == '') {
                errors.locationName = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new LocationMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Locations +'/' + values.locationId,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.LocationClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'LocationEdit', 
  })(LocationEditDisplay);

 
  interface IParams 
  {
     locationId:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface LocationEditComponentProps
  {
     match:IMatch;
  }

  interface LocationEditComponentState
  {
      model?:LocationViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class LocationEditComponent extends React.Component<LocationEditComponentProps, LocationEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Locations + '/' + this.props.match.params.locationId, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.LocationClientResponseModel;
            
            console.log(response);

			let mapper = new LocationMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
        else if (this.state.errorOccurred) {
			return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<LocationEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>a4d08071d0726b47e8ed4b131571ef2c</Hash>
</Codenesium>*/