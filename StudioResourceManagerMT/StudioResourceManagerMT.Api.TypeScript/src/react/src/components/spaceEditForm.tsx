import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import SpaceViewModel from '../viewmodels/spaceViewModel';
import SpaceMapper from '../mapping/spaceMapper';

interface Props {
    model?:SpaceViewModel
}

  const SpaceEditDisplay = (props: FormikProps<SpaceViewModel>) => {

   let status = props.status as UpdateResponse<Api.SpaceClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof SpaceViewModel]  && props.errors[name as keyof SpaceViewModel]) {
            response += props.errors[name as keyof SpaceViewModel];
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
                      <label htmlFor="name" className={errorExistForField("description") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Description</label>
					<div className="col-sm-12">
                         <Field type="input" name="description" className ={errorExistForField("description") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("description") && <small className="text-danger">{errorsForField("description")}</small>}

                    </div>
                </div>
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


const SpaceUpdate = withFormik<Props, SpaceViewModel>({
    mapPropsToValues: props => {
        let response = new SpaceViewModel();
		response.setProperties(props.model!.description,props.model!.id,props.model!.isDeleted,props.model!.name,props.model!.tenantId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<SpaceViewModel> = { };

	  if(values.description == '') {
                errors.description = "Required"
                    }if(values.id == 0) {
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
		  
	    let mapper = new SpaceMapper();

        axios.put(Constants.ApiUrl + 'spaces/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.SpaceClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as UpdateResponse<Api.SpaceClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'SpaceEdit', 
  })(SpaceEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface SpaceEditComponentProps
  {
     match:IMatch;
  }

  interface SpaceEditComponentState
  {
      model?:SpaceViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class SpaceEditComponent extends React.Component<SpaceEditComponentProps, SpaceEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'spaces/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.SpaceClientResponseModel;
            
            console.log(response);

			let mapper = new SpaceMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.SpaceClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<SpaceUpdate model={this.state.model} />);
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
    <Hash>377e89cb8c45842712ed9b15cefbc515</Hash>
</Codenesium>*/