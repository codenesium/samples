import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import TeacherSkillViewModel from '../viewmodels/teacherSkillViewModel';
import TeacherSkillMapper from '../mapping/teacherSkillMapper';

interface Props {
    model?:TeacherSkillViewModel
}

  const TeacherSkillEditDisplay = (props: FormikProps<TeacherSkillViewModel>) => {

   let status = props.status as UpdateResponse<Api.TeacherSkillClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof TeacherSkillViewModel]  && props.errors[name as keyof TeacherSkillViewModel]) {
            response += props.errors[name as keyof TeacherSkillViewModel];
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
                      <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					<div className="col-sm-12">
                         <Field type="input" name="id" className ={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("isDeleted") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>IsDeleted</label>
					<div className="col-sm-12">
                         <Field type="input" name="isDeleted" className ={errorExistForField("isDeleted") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("isDeleted") && <small className="text-danger">{errorsForField("isDeleted")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					<div className="col-sm-12">
                         <Field type="input" name="name" className ={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("tenantId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TenantId</label>
					<div className="col-sm-12">
                         <Field type="input" name="tenantId" className ={errorExistForField("tenantId") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("tenantId") && <small className="text-danger">{errorsForField("tenantId")}</small>}

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


const TeacherSkillUpdate = withFormik<Props, TeacherSkillViewModel>({
    mapPropsToValues: props => {
        let response = new TeacherSkillViewModel();
		response.setProperties(props.model!.id,props.model!.isDeleted,props.model!.name,props.model!.tenantId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<TeacherSkillViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }if(values.isDeleted == false) {
                errors.isDeleted = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.tenantId == 0) {
                errors.tenantId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new TeacherSkillMapper();

        axios.put(Constants.ApiUrl + 'teacherskills/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.TeacherSkillClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as UpdateResponse<Api.TeacherSkillClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'TeacherSkillEdit', 
  })(TeacherSkillEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface TeacherSkillEditComponentProps
  {
     match:IMatch;
  }

  interface TeacherSkillEditComponentState
  {
      model?:TeacherSkillViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class TeacherSkillEditComponent extends React.Component<TeacherSkillEditComponentProps, TeacherSkillEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'teacherskills/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.TeacherSkillClientResponseModel;
            
            console.log(response);

			let mapper = new TeacherSkillMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.TeacherSkillClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<TeacherSkillUpdate model={this.state.model} />);
        } 
        else if (this.state.errorOccurred) {
            return (<div>{this.state.errorMessage}</div>);
        }
        else {
            return (<div></div>);   
        }
    }
}

/*<Codenesium>
    <Hash>b49b79b939a97943cbda0feaf07fb7f0</Hash>
</Codenesium>*/