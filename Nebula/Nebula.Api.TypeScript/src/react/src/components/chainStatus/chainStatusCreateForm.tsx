import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ChainStatusMapper from './chainStatusMapper';
import ChainStatusViewModel from './chainStatusViewModel';

interface Props {
    model?:ChainStatusViewModel
}

   const ChainStatusCreateDisplay: React.SFC<FormikProps<ChainStatusViewModel>> = (props: FormikProps<ChainStatusViewModel>) => {

   let status = props.status as CreateResponse<Api.ChainStatusClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof ChainStatusViewModel]  && props.errors[name as keyof ChainStatusViewModel]) {
            response += props.errors[name as keyof ChainStatusViewModel];
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
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
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


const ChainStatusCreate = withFormik<Props, ChainStatusViewModel>({
    mapPropsToValues: props => {
                
		let response = new ChainStatusViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.name);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<ChainStatusViewModel> = { };

	  if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new ChainStatusMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.ChainStatuses,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.ChainStatusClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'ChainStatusCreate', 
  })(ChainStatusCreateDisplay);

  interface ChainStatusCreateComponentProps
  {
  }

  interface ChainStatusCreateComponentState
  {
      model?:ChainStatusViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ChainStatusCreateComponent extends React.Component<ChainStatusCreateComponentProps, ChainStatusCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ChainStatusCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d694df071993451d79e79927ab05b116</Hash>
</Codenesium>*/