import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import CustomerCommunicationViewModel from './customerCommunicationViewModel';
import CustomerCommunicationMapper from './customerCommunicationMapper';

interface Props {
    model?:CustomerCommunicationViewModel
}

  const CustomerCommunicationEditDisplay = (props: FormikProps<CustomerCommunicationViewModel>) => {

   let status = props.status as UpdateResponse<Api.CustomerCommunicationClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof CustomerCommunicationViewModel]  && props.errors[name as keyof CustomerCommunicationViewModel]) {
            response += props.errors[name as keyof CustomerCommunicationViewModel];
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
                        <label htmlFor="name" className={errorExistForField("customerId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CustomerId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="customerId" className={errorExistForField("customerId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("customerId") && <small className="text-danger">{errorsForField("customerId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("dateCreated") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DateCreated</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="dateCreated" className={errorExistForField("dateCreated") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dateCreated") && <small className="text-danger">{errorsForField("dateCreated")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("employeeId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>EmployeeId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="employeeId" className={errorExistForField("employeeId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("employeeId") && <small className="text-danger">{errorsForField("employeeId")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("note") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Notes</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="note" className={errorExistForField("note") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("note") && <small className="text-danger">{errorsForField("note")}</small>}
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


const CustomerCommunicationEdit = withFormik<Props, CustomerCommunicationViewModel>({
    mapPropsToValues: props => {
        let response = new CustomerCommunicationViewModel();
		response.setProperties(props.model!.customerId,props.model!.dateCreated,props.model!.employeeId,props.model!.id,props.model!.note);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<CustomerCommunicationViewModel> = { };

	  if(values.customerId == 0) {
                errors.customerId = "Required"
                    }if(values.dateCreated == undefined) {
                errors.dateCreated = "Required"
                    }if(values.employeeId == 0) {
                errors.employeeId = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.note == '') {
                errors.note = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new CustomerCommunicationMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.CustomerCommunications +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.CustomerCommunicationClientRequestModel>;
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
  
    displayName: 'CustomerCommunicationEdit', 
  })(CustomerCommunicationEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface CustomerCommunicationEditComponentProps
  {
     match:IMatch;
  }

  interface CustomerCommunicationEditComponentState
  {
      model?:CustomerCommunicationViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class CustomerCommunicationEditComponent extends React.Component<CustomerCommunicationEditComponentProps, CustomerCommunicationEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.CustomerCommunications + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.CustomerCommunicationClientResponseModel;
            
            console.log(response);

			let mapper = new CustomerCommunicationMapper();

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
            return (<CustomerCommunicationEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>89d4abf093902f43b515d0494bfa8770</Hash>
</Codenesium>*/