import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import StudentViewModel from './studentViewModel';
import StudentMapper from './studentMapper';

interface Props {
    model?:StudentViewModel
}

  const StudentEditDisplay = (props: FormikProps<StudentViewModel>) => {

   let status = props.status as UpdateResponse<Api.StudentClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof StudentViewModel]  && props.errors[name as keyof StudentViewModel]) {
            response += props.errors[name as keyof StudentViewModel];
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
                        <label htmlFor="name" className={errorExistForField("emailRemindersEnabled") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>EmailRemindersEnabled</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="emailRemindersEnabled" className={errorExistForField("emailRemindersEnabled") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("emailRemindersEnabled") && <small className="text-danger">{errorsForField("emailRemindersEnabled")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("familyId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FamilyId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="familyId" className={errorExistForField("familyId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("familyId") && <small className="text-danger">{errorsForField("familyId")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("isAdult") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>IsAdult</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="isAdult" className={errorExistForField("isAdult") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("isAdult") && <small className="text-danger">{errorsForField("isAdult")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("smsRemindersEnabled") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SmsRemindersEnabled</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="smsRemindersEnabled" className={errorExistForField("smsRemindersEnabled") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("smsRemindersEnabled") && <small className="text-danger">{errorsForField("smsRemindersEnabled")}</small>}
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


const StudentEdit = withFormik<Props, StudentViewModel>({
    mapPropsToValues: props => {
        let response = new StudentViewModel();
		response.setProperties(props.model!.birthday,props.model!.email,props.model!.emailRemindersEnabled,props.model!.familyId,props.model!.firstName,props.model!.id,props.model!.isAdult,props.model!.lastName,props.model!.phone,props.model!.smsRemindersEnabled,props.model!.userId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<StudentViewModel> = { };

	  if(values.birthday == undefined) {
                errors.birthday = "Required"
                    }if(values.email == '') {
                errors.email = "Required"
                    }if(values.familyId == 0) {
                errors.familyId = "Required"
                    }if(values.firstName == '') {
                errors.firstName = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.lastName == '') {
                errors.lastName = "Required"
                    }if(values.phone == '') {
                errors.phone = "Required"
                    }if(values.userId == 0) {
                errors.userId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new StudentMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Students +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.StudentClientRequestModel>;
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
  
    displayName: 'StudentEdit', 
  })(StudentEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface StudentEditComponentProps
  {
     match:IMatch;
  }

  interface StudentEditComponentState
  {
      model?:StudentViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class StudentEditComponent extends React.Component<StudentEditComponentProps, StudentEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Students + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.StudentClientResponseModel;
            
            console.log(response);

			let mapper = new StudentMapper();

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
            return (<StudentEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>3b18b0534c71a79c26dc8197a40eb3de</Hash>
</Codenesium>*/