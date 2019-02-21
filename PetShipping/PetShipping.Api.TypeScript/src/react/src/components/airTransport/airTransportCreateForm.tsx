import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import AirTransportMapper from './airTransportMapper';
import AirTransportViewModel from './airTransportViewModel';

interface Props {
    model?:AirTransportViewModel
}

   const AirTransportCreateDisplay: React.SFC<FormikProps<AirTransportViewModel>> = (props: FormikProps<AirTransportViewModel>) => {

   let status = props.status as CreateResponse<Api.AirTransportClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof AirTransportViewModel]  && props.errors[name as keyof AirTransportViewModel]) {
            response += props.errors[name as keyof AirTransportViewModel];
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
                        <label htmlFor="name" className={errorExistForField("flightNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FlightNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="flightNumber" className={errorExistForField("flightNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("flightNumber") && <small className="text-danger">{errorsForField("flightNumber")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("handlerId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>HandlerId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="handlerId" className={errorExistForField("handlerId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("handlerId") && <small className="text-danger">{errorsForField("handlerId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("landDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LandDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="landDate" className={errorExistForField("landDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("landDate") && <small className="text-danger">{errorsForField("landDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("pipelineStepId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PipelineStepId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="pipelineStepId" className={errorExistForField("pipelineStepId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("pipelineStepId") && <small className="text-danger">{errorsForField("pipelineStepId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("takeoffDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TakeoffDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="takeoffDate" className={errorExistForField("takeoffDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("takeoffDate") && <small className="text-danger">{errorsForField("takeoffDate")}</small>}
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


const AirTransportCreate = withFormik<Props, AirTransportViewModel>({
    mapPropsToValues: props => {
                
		let response = new AirTransportViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.airlineId,props.model!.flightNumber,props.model!.handlerId,props.model!.id,props.model!.landDate,props.model!.pipelineStepId,props.model!.takeoffDate);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<AirTransportViewModel> = { };

	  if(values.flightNumber == '') {
                errors.flightNumber = "Required"
                    }if(values.handlerId == 0) {
                errors.handlerId = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.landDate == undefined) {
                errors.landDate = "Required"
                    }if(values.pipelineStepId == 0) {
                errors.pipelineStepId = "Required"
                    }if(values.takeoffDate == undefined) {
                errors.takeoffDate = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new AirTransportMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.AirTransports,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.AirTransportClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'AirTransportCreate', 
  })(AirTransportCreateDisplay);

  interface AirTransportCreateComponentProps
  {
  }

  interface AirTransportCreateComponentState
  {
      model?:AirTransportViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class AirTransportCreateComponent extends React.Component<AirTransportCreateComponentProps, AirTransportCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<AirTransportCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>09fb469cd4b1feac4c42e97e040f0603</Hash>
</Codenesium>*/