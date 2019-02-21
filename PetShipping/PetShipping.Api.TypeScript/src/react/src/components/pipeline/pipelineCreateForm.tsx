import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PipelineMapper from './pipelineMapper';
import PipelineViewModel from './pipelineViewModel';

interface Props {
    model?:PipelineViewModel
}

   const PipelineCreateDisplay: React.SFC<FormikProps<PipelineViewModel>> = (props: FormikProps<PipelineViewModel>) => {

   let status = props.status as CreateResponse<Api.PipelineClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof PipelineViewModel]  && props.errors[name as keyof PipelineViewModel]) {
            response += props.errors[name as keyof PipelineViewModel];
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
                        <label htmlFor="name" className={errorExistForField("pipelineStatusId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PipelineStatusId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="pipelineStatusId" className={errorExistForField("pipelineStatusId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("pipelineStatusId") && <small className="text-danger">{errorsForField("pipelineStatusId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("saleId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SaleId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="saleId" className={errorExistForField("saleId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("saleId") && <small className="text-danger">{errorsForField("saleId")}</small>}
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


const PipelineCreate = withFormik<Props, PipelineViewModel>({
    mapPropsToValues: props => {
                
		let response = new PipelineViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.pipelineStatusId,props.model!.saleId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<PipelineViewModel> = { };

	  if(values.pipelineStatusId == 0) {
                errors.pipelineStatusId = "Required"
                    }if(values.saleId == 0) {
                errors.saleId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new PipelineMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Pipelines,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.PipelineClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'PipelineCreate', 
  })(PipelineCreateDisplay);

  interface PipelineCreateComponentProps
  {
  }

  interface PipelineCreateComponentState
  {
      model?:PipelineViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PipelineCreateComponent extends React.Component<PipelineCreateComponentProps, PipelineCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<PipelineCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>2b8c80f1e12ab3574eaa4efa0af736b6</Hash>
</Codenesium>*/