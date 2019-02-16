import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PostHistoryTypeMapper from './postHistoryTypeMapper';
import PostHistoryTypeViewModel from './postHistoryTypeViewModel';

interface Props {
    model?:PostHistoryTypeViewModel
}

   const PostHistoryTypeCreateDisplay: React.SFC<FormikProps<PostHistoryTypeViewModel>> = (props: FormikProps<PostHistoryTypeViewModel>) => {

   let status = props.status as CreateResponse<Api.PostHistoryTypeClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof PostHistoryTypeViewModel]  && props.errors[name as keyof PostHistoryTypeViewModel]) {
            response += props.errors[name as keyof PostHistoryTypeViewModel];
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
                        <label htmlFor="name" className={errorExistForField("rwType") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Type</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="rwType" className={errorExistForField("rwType") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("rwType") && <small className="text-danger">{errorsForField("rwType")}</small>}
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


const PostHistoryTypeCreate = withFormik<Props, PostHistoryTypeViewModel>({
    mapPropsToValues: props => {
                
		let response = new PostHistoryTypeViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.rwType);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<PostHistoryTypeViewModel> = { };

	  if(values.rwType == '') {
                errors.rwType = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new PostHistoryTypeMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.PostHistoryTypes,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.PostHistoryTypeClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'PostHistoryTypeCreate', 
  })(PostHistoryTypeCreateDisplay);

  interface PostHistoryTypeCreateComponentProps
  {
  }

  interface PostHistoryTypeCreateComponentState
  {
      model?:PostHistoryTypeViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PostHistoryTypeCreateComponent extends React.Component<PostHistoryTypeCreateComponentProps, PostHistoryTypeCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<PostHistoryTypeCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>ef358c626816075e91a4efa4a0532a90</Hash>
</Codenesium>*/