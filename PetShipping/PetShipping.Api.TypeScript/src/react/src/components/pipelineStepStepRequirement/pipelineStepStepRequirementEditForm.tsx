import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PipelineStepStepRequirementViewModel from './pipelineStepStepRequirementViewModel';
import PipelineStepStepRequirementMapper from './pipelineStepStepRequirementMapper';

interface Props {
    model?:PipelineStepStepRequirementViewModel
}

  const PipelineStepStepRequirementEditDisplay = (props: FormikProps<PipelineStepStepRequirementViewModel>) => {

   let status = props.status as UpdateResponse<Api.PipelineStepStepRequirementClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof PipelineStepStepRequirementViewModel]  && props.errors[name as keyof PipelineStepStepRequirementViewModel]) {
            response += props.errors[name as keyof PipelineStepStepRequirementViewModel];
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
                        <label htmlFor="name" className={errorExistForField("detail") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Details</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="detail" className={errorExistForField("detail") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("detail") && <small className="text-danger">{errorsForField("detail")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("pipelineStepId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PipelineStepId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="pipelineStepId" className={errorExistForField("pipelineStepId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("pipelineStepId") && <small className="text-danger">{errorsForField("pipelineStepId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("requirementMet") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>RequirementMet</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="requirementMet" className={errorExistForField("requirementMet") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("requirementMet") && <small className="text-danger">{errorsForField("requirementMet")}</small>}
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


const PipelineStepStepRequirementEdit = withFormik<Props, PipelineStepStepRequirementViewModel>({
    mapPropsToValues: props => {
        let response = new PipelineStepStepRequirementViewModel();
		response.setProperties(props.model!.detail,props.model!.id,props.model!.pipelineStepId,props.model!.requirementMet);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<PipelineStepStepRequirementViewModel> = { };

	  if(values.detail == '') {
                errors.detail = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.pipelineStepId == 0) {
                errors.pipelineStepId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new PipelineStepStepRequirementMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.PipelineStepStepRequirements +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.PipelineStepStepRequirementClientRequestModel>;
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
  
    displayName: 'PipelineStepStepRequirementEdit', 
  })(PipelineStepStepRequirementEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface PipelineStepStepRequirementEditComponentProps
  {
     match:IMatch;
  }

  interface PipelineStepStepRequirementEditComponentState
  {
      model?:PipelineStepStepRequirementViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PipelineStepStepRequirementEditComponent extends React.Component<PipelineStepStepRequirementEditComponentProps, PipelineStepStepRequirementEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.PipelineStepStepRequirements + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PipelineStepStepRequirementClientResponseModel;
            
            console.log(response);

			let mapper = new PipelineStepStepRequirementMapper();

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
            return (<PipelineStepStepRequirementEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>152b7e44fbf2362f43f57508fe007642</Hash>
</Codenesium>*/