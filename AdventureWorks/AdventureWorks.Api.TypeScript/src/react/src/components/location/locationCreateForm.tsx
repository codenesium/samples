import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import LocationMapper from './locationMapper';
import LocationViewModel from './locationViewModel';

interface Props {
    model?:LocationViewModel
}

   const LocationCreateDisplay: React.SFC<FormikProps<LocationViewModel>> = (props: FormikProps<LocationViewModel>) => {

   let status = props.status as CreateResponse<Api.LocationClientRequestModel>;
   
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

   return (<form onSubmit={props.handleSubmit} role="form">            
            			<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("availability") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Availability</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="availability" className={errorExistForField("availability") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("availability") && <small className="text-danger">{errorsForField("availability")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("costRate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CostRate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="costRate" className={errorExistForField("costRate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("costRate") && <small className="text-danger">{errorsForField("costRate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
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
          </form>);
}


const LocationCreate = withFormik<Props, LocationViewModel>({
    mapPropsToValues: props => {
                
		let response = new LocationViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.availability,props.model!.costRate,props.model!.locationID,props.model!.modifiedDate,props.model!.name);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<LocationViewModel> = { };

	  if(values.availability == 0) {
                errors.availability = "Required"
                    }if(values.costRate == 0) {
                errors.costRate = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new LocationMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Locations,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.LocationClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'LocationCreate', 
  })(LocationCreateDisplay);

  interface LocationCreateComponentProps
  {
  }

  interface LocationCreateComponentState
  {
      model?:LocationViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class LocationCreateComponent extends React.Component<LocationCreateComponentProps, LocationCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<LocationCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>a3cc288b3af5f858f4ed386358d3d458</Hash>
</Codenesium>*/