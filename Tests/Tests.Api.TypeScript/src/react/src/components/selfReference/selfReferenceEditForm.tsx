import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import SelfReferenceViewModel from './selfReferenceViewModel';
import SelfReferenceMapper from './selfReferenceMapper';

interface Props {
    model?:SelfReferenceViewModel
}

  const SelfReferenceEditDisplay = (props: FormikProps<SelfReferenceViewModel>) => {

   let status = props.status as UpdateResponse<Api.SelfReferenceClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof SelfReferenceViewModel]  && props.errors[name as keyof SelfReferenceViewModel]) {
            response += props.errors[name as keyof SelfReferenceViewModel];
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
                             <Field type="textbox" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("selfReferenceId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SelfReferenceId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="selfReferenceId" className={errorExistForField("selfReferenceId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("selfReferenceId") && <small className="text-danger">{errorsForField("selfReferenceId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("selfReferenceId2") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SelfReferenceId2</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="selfReferenceId2" className={errorExistForField("selfReferenceId2") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("selfReferenceId2") && <small className="text-danger">{errorsForField("selfReferenceId2")}</small>}
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


const SelfReferenceEdit = withFormik<Props, SelfReferenceViewModel>({
    mapPropsToValues: props => {
        let response = new SelfReferenceViewModel();
		response.setProperties(props.model!.id,props.model!.selfReferenceId,props.model!.selfReferenceId2);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<SelfReferenceViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new SelfReferenceMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.SelfReferences +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.SelfReferenceClientRequestModel>;
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
  
    displayName: 'SelfReferenceEdit', 
  })(SelfReferenceEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface SelfReferenceEditComponentProps
  {
     match:IMatch;
  }

  interface SelfReferenceEditComponentState
  {
      model?:SelfReferenceViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class SelfReferenceEditComponent extends React.Component<SelfReferenceEditComponentProps, SelfReferenceEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.SelfReferences + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.SelfReferenceClientResponseModel;
            
            console.log(response);

			let mapper = new SelfReferenceMapper();

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
            return (<SelfReferenceEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>effe1266a94f4f548c01698d054a0ff4</Hash>
</Codenesium>*/