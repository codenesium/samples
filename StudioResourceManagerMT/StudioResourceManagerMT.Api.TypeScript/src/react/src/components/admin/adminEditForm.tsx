import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import AdminViewModel from './adminViewModel';
import AdminMapper from './adminMapper';

interface Props {
    model?:AdminViewModel
}

  const AdminEditDisplay = (props: FormikProps<AdminViewModel>) => {

   let status = props.status as UpdateResponse<Api.AdminClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof AdminViewModel]  && props.errors[name as keyof AdminViewModel]) {
            response += props.errors[name as keyof AdminViewModel];
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
                        <label htmlFor="name" className={errorExistForField("birthday") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Birthday</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="birthday" className={errorExistForField("birthday") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("birthday") && <small className="text-danger">{errorsForField("birthday")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("email") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Email</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="email" className={errorExistForField("email") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("email") && <small className="text-danger">{errorsForField("email")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("firstName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FirstName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="firstName" className={errorExistForField("firstName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("firstName") && <small className="text-danger">{errorsForField("firstName")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("lastName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="lastName" className={errorExistForField("lastName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastName") && <small className="text-danger">{errorsForField("lastName")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("phone") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Phone</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="phone" className={errorExistForField("phone") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("phone") && <small className="text-danger">{errorsForField("phone")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("userId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>UserId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="userId" className={errorExistForField("userId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("userId") && <small className="text-danger">{errorsForField("userId")}</small>}
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


const AdminEdit = withFormik<Props, AdminViewModel>({
    mapPropsToValues: props => {
        let response = new AdminViewModel();
		response.setProperties(props.model!.birthday,props.model!.email,props.model!.firstName,props.model!.id,props.model!.lastName,props.model!.phone,props.model!.userId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<AdminViewModel> = { };

	  if(values.email == '') {
                errors.email = "Required"
                    }if(values.firstName == '') {
                errors.firstName = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.lastName == '') {
                errors.lastName = "Required"
                    }if(values.userId == 0) {
                errors.userId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new AdminMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Admins +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.AdminClientRequestModel>;
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
  
    displayName: 'AdminEdit', 
  })(AdminEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface AdminEditComponentProps
  {
     match:IMatch;
  }

  interface AdminEditComponentState
  {
      model?:AdminViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class AdminEditComponent extends React.Component<AdminEditComponentProps, AdminEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Admins + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.AdminClientResponseModel;
            
            console.log(response);

			let mapper = new AdminMapper();

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
            return (<AdminEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>8a8b7642e0776ca7cf213fdcbb2addf0</Hash>
</Codenesium>*/