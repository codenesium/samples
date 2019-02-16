import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import UserViewModel from './userViewModel';
import UserMapper from './userMapper';

interface Props {
    model?:UserViewModel
}

  const UserEditDisplay = (props: FormikProps<UserViewModel>) => {

   let status = props.status as UpdateResponse<Api.UserClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof UserViewModel]  && props.errors[name as keyof UserViewModel]) {
            response += props.errors[name as keyof UserViewModel];
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
                        <label htmlFor="name" className={errorExistForField("password") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Password</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="password" className={errorExistForField("password") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("password") && <small className="text-danger">{errorsForField("password")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("username") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Username</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="username" className={errorExistForField("username") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("username") && <small className="text-danger">{errorsForField("username")}</small>}
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


const UserEdit = withFormik<Props, UserViewModel>({
    mapPropsToValues: props => {
        let response = new UserViewModel();
		response.setProperties(props.model!.id,props.model!.password,props.model!.username);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<UserViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }if(values.password == '') {
                errors.password = "Required"
                    }if(values.username == '') {
                errors.username = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new UserMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Users +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.UserClientRequestModel>;
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
  
    displayName: 'UserEdit', 
  })(UserEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface UserEditComponentProps
  {
     match:IMatch;
  }

  interface UserEditComponentState
  {
      model?:UserViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class UserEditComponent extends React.Component<UserEditComponentProps, UserEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.UserClientResponseModel;
            
            console.log(response);

			let mapper = new UserMapper();

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
            return (<UserEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>8723ecd29bc69ac727e75571a88dd8e9</Hash>
</Codenesium>*/