import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import CustomerCommunicationMapper from './customerCommunicationMapper';
import CustomerCommunicationViewModel from './customerCommunicationViewModel';

interface Props {
    model?:CustomerCommunicationViewModel
}

   const CustomerCommunicationCreateDisplay: React.SFC<FormikProps<CustomerCommunicationViewModel>> = (props: FormikProps<CustomerCommunicationViewModel>) => {

   let status = props.status as CreateResponse<Api.CustomerCommunicationClientRequestModel>;
   
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

   return (<form onSubmit={props.handleSubmit} role="form">            
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
          </form>);
}


const CustomerCommunicationCreate = withFormik<Props, CustomerCommunicationViewModel>({
    mapPropsToValues: props => {
                
		let response = new CustomerCommunicationViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.customerId,props.model!.dateCreated,props.model!.employeeId,props.model!.id,props.model!.note);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<CustomerCommunicationViewModel> = { };

	  if(values.customerId == 0) {
                errors.customerId = "Required"
                    }if(values.dateCreated == undefined) {
                errors.dateCreated = "Required"
                    }if(values.employeeId == 0) {
                errors.employeeId = "Required"
                    }if(values.note == '') {
                errors.note = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new CustomerCommunicationMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.CustomerCommunications,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.CustomerCommunicationClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'CustomerCommunicationCreate', 
  })(CustomerCommunicationCreateDisplay);

  interface CustomerCommunicationCreateComponentProps
  {
  }

  interface CustomerCommunicationCreateComponentState
  {
      model?:CustomerCommunicationViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class CustomerCommunicationCreateComponent extends React.Component<CustomerCommunicationCreateComponentProps, CustomerCommunicationCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<CustomerCommunicationCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>8148561535c599c712f295c2e35daddf</Hash>
</Codenesium>*/